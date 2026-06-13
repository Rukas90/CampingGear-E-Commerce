import { loadStripe, type Appearance } from "@stripe/stripe-js"
import { Elements } from "@stripe/react-stripe-js"
import { useNavigate, useParams } from "react-router-dom"
import type { OrderToken } from "@types"
import { PaymentForm } from "@components"

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLISHABLE_KEY)

const appearance: Appearance = {
  theme: "flat",
  labels: "floating",
  variables: {
    colorPrimary: "#859277",
    colorDanger: "#b06363",
    colorSuccess: "#49ab65",
  },
}

const PaymentPage = () => {
  const { orderToken } = useParams<{ orderToken: OrderToken }>()
  const navigate = useNavigate()

  if (!orderToken) {
    navigate("/")
    return
  }

  return (
    <Elements
      stripe={stripePromise}
      options={{
        mode: "payment",
        amount: 1234,
        currency: "eur",
        appearance,
      }}
    >
      <PaymentForm token={orderToken} />
    </Elements>
  )
}
export default PaymentPage
