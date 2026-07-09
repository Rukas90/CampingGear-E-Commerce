import { useNavigate, useParams } from "react-router-dom"
import type { OrderToken } from "@types"
import { PaymentForm } from "@components"
import { PaymentProvider } from "@features/payments"
import { usePayment } from "@features"
import { loadStripe } from "@stripe/stripe-js"
import { Elements } from "@stripe/react-stripe-js"

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLISHABLE_KEY)

const PaymentPage = () => {
  const { orderToken } = useParams<{ orderToken: OrderToken }>()
  const { payment, isPending } = usePayment(orderToken)
  const navigate = useNavigate()

  if (isPending) {
    return <p>Loading...</p>
  }
  if (!payment) {
    navigate("/")
    return
  }

  return (
    <Elements
      stripe={stripePromise}
      options={{
        clientSecret: payment.clientSecret,
        appearance: {
          theme: "flat",
          labels: "floating",
          variables: {
            colorPrimary: "#859277",
            colorDanger: "#b06363",
            colorSuccess: "#49ab65",
          },
        },
      }}
    >
      <PaymentProvider payment={payment}>
        <PaymentForm />
      </PaymentProvider>
    </Elements>
  )
}
export default PaymentPage
