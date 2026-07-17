import { useNavigate, useParams } from "react-router-dom"
import type { OrderId } from "@types"
import { PaymentForm } from "@components"
import { PaymentProvider } from "@features/payments"
import { usePayment } from "@features"
import { loadStripe } from "@stripe/stripe-js"
import { Elements } from "@stripe/react-stripe-js"

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLISHABLE_KEY)

const PaymentPage = () => {
  const { orderId } = useParams<{ orderId: OrderId }>()
  const { payment, isPending } = usePayment(orderId)
  const navigate = useNavigate()

  if (isPending) {
    return <p>Loading...</p>
  }

  if (!payment || payment.attemptsRemaining <= 0 || payment.isComplete) {
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
      <title>Trailstore - Pay</title>
      <PaymentProvider orderId={orderId!} payment={payment}>
        <PaymentForm />
      </PaymentProvider>
    </Elements>
  )
}
export default PaymentPage
