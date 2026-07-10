import { useElements, useStripe } from "@stripe/react-stripe-js"
import { useCallback, useEffect, useReducer, useRef } from "react"
import {
  type OrderSummary,
  type Payment,
  type PaymentAttemptId,
  type ProblemDetails,
  PaymentStatus,
} from "@types"
import paymentsApi from "../api/paymentsApi"

export type ConfirmationState =
  | { phase: "idle" }
  | { phase: "issuing" }
  | { phase: "confirming" }
  | { phase: "polling" }
  | { phase: "succeeded" }
  | { phase: "already_complete" }
  | { phase: "failed"; message: string }

type Action =
  | { type: "ISSUING" }
  | { type: "CONFIRMING" }
  | { type: "POLLING" }
  | { type: "SUCCEEDED" }
  | { type: "ALREADY_COMPLETE" }
  | { type: "FAILED"; message: string }
  | { type: "RESET" }

function reducer(_: ConfirmationState, action: Action): ConfirmationState {
  switch (action.type) {
    case "ISSUING":
      return { phase: "issuing" }
    case "CONFIRMING":
      return { phase: "confirming" }
    case "POLLING":
      return { phase: "polling" }
    case "SUCCEEDED":
      return { phase: "succeeded" }
    case "ALREADY_COMPLETE":
      return { phase: "already_complete" }
    case "FAILED":
      return { phase: "failed", message: action.message }
    case "RESET":
      return { phase: "idle" }
  }
}

const getMessage = (error?: ProblemDetails) =>
  error?.errors[0]?.reason ??
  error?.detail ??
  error?.title ??
  "Something went wrong."

const POLL_INTERVAL_MS = 2000

interface PaymentConfirmationProps {
  payment: Payment
  order?: OrderSummary
  redirectUrl: string
  disabled?: boolean
}

const usePaymentConfirmation = ({
  payment,
  order,
  redirectUrl,
  disabled,
}: PaymentConfirmationProps) => {
  const [state, dispatch] = useReducer(reducer, { phase: "idle" })
  const stripe = useStripe()
  const elements = useElements()
  const pollHandle = useRef<ReturnType<typeof setInterval> | null>(null)

  const stopPolling = useCallback(() => {
    if (pollHandle.current) {
      clearInterval(pollHandle.current)
      pollHandle.current = null
    }
  }, [])

  useEffect(() => () => stopPolling(), [stopPolling])

  const pollAttempt = useCallback(
    (attemptId: PaymentAttemptId) => {
      dispatch({ type: "POLLING" })

      pollHandle.current = setInterval(async () => {
        const result = await paymentsApi.getAttemptStatus(attemptId)

        if (!result.isSuccess) {
          stopPolling()
          dispatch({ type: "FAILED", message: getMessage(result.error) })
          return
        }

        const status = result.data!.status

        if (status === "pending") {
          return
        }

        stopPolling()

        switch (status) {
          case PaymentStatus.Succeeded:
            dispatch({ type: "SUCCEEDED" })
            break
          case PaymentStatus.Failed:
            dispatch({
              type: "FAILED",
              message: "Your payment could not be completed.",
            })
            break
          case PaymentStatus.Canceled:
            dispatch({
              type: "FAILED",
              message: "This payment attempt was canceled.",
            })
            break
        }
      }, POLL_INTERVAL_MS)
    },
    [stopPolling],
  )

  const confirm = useCallback(async () => {
    if (!stripe || !elements || state.phase !== "idle" || disabled || !order) {
      return
    }

    dispatch({ type: "ISSUING" })

    const issued = await paymentsApi.issueAttempt(payment.paymentId)

    if (!issued.isSuccess) {
      if (
        issued.error?.errors.some((e) => e.code === "payment.already_complete")
      ) {
        dispatch({ type: "ALREADY_COMPLETE" })
      } else {
        dispatch({ type: "FAILED", message: getMessage(issued.error) })
      }
      return
    }

    dispatch({ type: "CONFIRMING" })

    const { error: submitError } = await elements.submit()
    if (submitError) {
      dispatch({
        type: "FAILED",
        message: submitError.message ?? "Invalid payment details",
      })
      return
    }

    const { error: confirmError } = await stripe.confirmPayment({
      elements,
      clientSecret: payment.clientSecret,
      redirect: "if_required",
      confirmParams: {
        return_url: redirectUrl,
        payment_method_data: {
          billing_details: {
            name: order.billing.recipientFirstName,
            email: order.emailAddress,
            phone: order.billing.phoneNumber,
            address: {
              city: order.billing.city,
              country: order.billing.countryCode,
              line1: order.billing.addressLine,
              line2: order.billing.apartmentSuite,
              postal_code: order.billing.postalCode,
              state: order.billing.region,
            },
          },
        },
      },
    })

    if (confirmError) {
      dispatch({
        type: "FAILED",
        message: confirmError.message ?? "Payment failed",
      })
      return
    }

    pollAttempt(issued.data!.attemptId)
  }, [stripe, elements, state.phase, payment, pollAttempt, order, redirectUrl])

  const reset = useCallback(() => {
    stopPolling()
    dispatch({ type: "RESET" })
  }, [stopPolling])

  return { state, confirm, reset }
}
export default usePaymentConfirmation
