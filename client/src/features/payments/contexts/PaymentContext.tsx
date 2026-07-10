import { useOrder } from "@features/orders"
import { type Payment, type OrderSummary, type OrderId } from "@types"
import { createContext, useContext, useEffect } from "react"
import { useNavigate } from "react-router-dom"
import usePaymentConfirmation, {
  type ConfirmationState,
} from "../hooks/usePaymentConfirmation"

interface PaymentContextData {
  order: OrderSummary
  state: ConfirmationState
  actions: {
    confirm: () => void
  }
}

const PaymentContext = createContext<PaymentContextData | undefined>(undefined)

interface PaymentContextProps {
  orderId: OrderId
  payment: Payment
}

const PaymentProvider = ({
  orderId,
  payment,
  children,
}: React.PropsWithChildren<PaymentContextProps>) => {
  const { order, isPending } = useOrder(orderId)
  const { state, confirm } = usePaymentConfirmation({
    payment,
    order,
    redirectUrl: `http://localhost:5173/thank-you/${orderId}`,
  })
  const navigate = useNavigate()

  useEffect(() => {
    if (state.phase === "succeeded") navigate(`/thank-you/${orderId}`)
    if (state.phase === "already_complete") navigate(`/thank-you/${orderId}`)
  }, [state.phase, orderId, navigate])

  if (isPending) {
    return <p>Loading...</p>
  }

  if (!order) {
    navigate("/")
    return
  }

  return (
    <PaymentContext.Provider
      value={{
        order: order,
        state,
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
