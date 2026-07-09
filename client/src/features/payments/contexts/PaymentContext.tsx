import { useElements, useStripe } from "@stripe/react-stripe-js"
import type { OrderPayment, OrderSummary } from "@types"
import { createContext, useContext, useState } from "react"

interface PaymentContextData {
  order: OrderSummary
  isProcessing: boolean
  error: string | null
  actions: {
    confirm: () => void
  }
}

const PaymentContext = createContext<PaymentContextData | undefined>(undefined)

interface PaymentContextProps {
  payment: OrderPayment
}

const PaymentProvider = ({
  payment,
  children,
}: React.PropsWithChildren<PaymentContextProps>) => {
  const stripe = useStripe()
  const elements = useElements()
  const [error, setError] = useState<string | null>(null)
  const [isProcessing, setIsProcessing] = useState(false)

  const confirm = async () => {
    if (!stripe || !elements || isProcessing) {
      return
    }

    setError(null)
    setIsProcessing(true)

    const { error: submitError } = await elements.submit()

    if (submitError) {
      setError(submitError.message ?? "Invalid payment details")
      setIsProcessing(false)

      return
    }

    const { error: confirmError } = await stripe.confirmPayment({
      elements: elements ?? undefined,
      clientSecret: payment.clientSecret,
      confirmParams: {
        return_url: `http://localhost:5173/thank-you/${payment.order.token}`,
        payment_method_data: {
          billing_details: {
            name: payment.billing.recipientFirstName,
            email: payment.order.emailAddress,
            phone: payment.billing.phoneNumber,
            address: {
              city: payment.billing.city,
              country: payment.billing.countryCode,
              line1: payment.billing.addressLine,
              line2: payment.billing.apartmentSuite,
              postal_code: payment.billing.postalCode,
              state: payment.billing.region,
            },
          },
        },
      },
    })

    if (confirmError) {
      setError(confirmError.message ?? "Payment failed")
    }

    setIsProcessing(false)
  }

  return (
    <PaymentContext.Provider
      value={{
        order: payment.order,
        isProcessing,
        error,
        actions: {
          confirm,
        },
      }}
    >
      {children}
    </PaymentContext.Provider>
  )
}

export default PaymentProvider

export const usePaymentContext = () => {
  const context = useContext(PaymentContext)

  if (!context) {
    throw new Error(
      "usePaymentContext can only be used within the PaymentProvider.",
    )
  }

  return context
}
