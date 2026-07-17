import { useElements, useStripe } from "@stripe/react-stripe-js"
import { useCallback, useEffect, useRef, useState } from "react"
import {
  type OrderDetails,
  type Payment,
  type PaymentAttemptId,
  type ProblemDetails,
  PaymentStatus,
} from "@types"
import paymentsApi from "../api/paymentsApi"

export type ConfirmationState = "idle" | "issuing" | "confirming" | "polling"

const getMessage = (error?: ProblemDetails) =>
  error?.errors[0]?.reason ??
  error?.detail ??
  error?.title ??
  "Something went wrong."

const POLL_INTERVAL_MS = 2000

interface PaymentConfirmationProps {
  payment: Payment
  order?: OrderDetails
  redirectAbsoluteUrl: string
  disabled?: boolean
  onComplete?: () => void
  onFailed?: () => void
  onCanceled?: () => void
}

const usePaymentConfirmation = ({
  payment,
  order,
  redirectAbsoluteUrl,
  disabled,
  onComplete,
  onFailed,
  onCanceled,
}: PaymentConfirmationProps) => {
  const [state, setState] = useState<ConfirmationState>("idle")
  const [error, setError] = useState<string | null>(null)
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
      setState("polling")

      pollHandle.current = setInterval(async () => {
        const result = await paymentsApi.getAttemptStatus(attemptId)

        if (!result.isSuccess) {
          stopPolling()
          setState("idle")

          return
        }

        const status = result.data!.status

        if (status === "pending") {
          return
        }

        stopPolling()

        switch (status) {
          case PaymentStatus.Succeeded:
            onComplete?.()
            break
          case PaymentStatus.Failed:
            onFailed?.()
            setError("Your payment could not be completed.")
            break
          case PaymentStatus.Canceled:
            onCanceled?.()
            setError("This payment attempt was canceled.")
            break
        }

        setState("idle")
      }, POLL_INTERVAL_MS)
    },
    [stopPolling, onComplete, onFailed, onCanceled],
  )

  const confirm = useCallback(async () => {
    if (!stripe || !elements || state !== "idle" || disabled || !order) {
      return
    }

    setError(null)

    const { error: submitError } = await elements.submit()
    if (submitError) {
      setError(submitError.message ?? "Invalid payment details")
      return
    }

    setState("issuing")

    const issued = await paymentsApi.issueAttempt(payment.paymentId)

    if (!issued.isSuccess) {
      if (
        issued.error?.errors.some((e) => e.code === "payment.already_complete")
      ) {
        onComplete?.()
      } else {
        setError(getMessage(issued.error))
      }

      setState("idle")
      return
    }

    setState("confirming")

    await stripe.confirmPayment({
      elements,
      clientSecret: payment.clientSecret,
      redirect: "if_required",
      confirmParams: {
        return_url: redirectAbsoluteUrl,
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
    pollAttempt(issued.data!.attemptId)
  }, [
    stripe,
    elements,
    state,
    error,
    payment,
    pollAttempt,
    order,
    redirectAbsoluteUrl,
    disabled,
  ])

  return { state, confirm }
}
export default usePaymentConfirmation
