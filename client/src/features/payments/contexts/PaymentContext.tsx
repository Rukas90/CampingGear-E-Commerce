import { useOrder } from "@features/orders"
import { type Payment, type OrderSummary, type OrderId } from "@types"
import { createContext, useContext, useRef, useState } from "react"
import { useNavigate } from "react-router-dom"
import usePaymentConfirmation, {
  type ConfirmationState,
} from "../hooks/usePaymentConfirmation"
import paymentsApi from "../api/paymentsApi"

interface PaymentContextData {
  order: OrderSummary
  state: ConfirmationState
  actions: {
    confirm: () => void
    cancel: () => void
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
  const attemptsRemaining = useRef(payment.attemptsRemaining)
  const [canceling, setCanceling] = useState(false)
  const navigate = useNavigate()
  const { state, confirm } = usePaymentConfirmation({
    payment,
    order,
    redirectAbsoluteUrl: `${window.location.origin}/orders/confirmation/${orderId}`,
    onComplete: async () => navigate(`/orders/confirmation/${orderId}`),
    onFailed: async () => {
      attemptsRemaining.current--

      if (attemptsRemaining.current <= 0) {
        navigate(`/orders/failed/${orderId}`)
      }
    },
    disabled: canceling,
  })

  if (isPending) {
    return <p>Loading...</p>
  }

  if (!order) {
    navigate("/")
    return
  }

  const cancelPayment = async () => {
    setCanceling(true)
    const result = await paymentsApi.cancel(payment.paymentId)

    if (result.isSuccess) {
      navigate(`/orders/failed/${orderId}`)
    }
    setCanceling(false)
  }

  return (
    <PaymentContext.Provider
      value={{
        order,
        state,
        actions: {
          confirm,
          cancel: cancelPayment,
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
