import type { OrderId, ProblemDetails } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useMutateHandler } from "@features"

const useCheckoutConfirm = ({
  onSuccess,
  onError,
}: {
  onSuccess: (id: OrderId) => void
  onError: (problem: ProblemDetails) => void
}) => {
  return useMutateHandler({
    key: ["checkout-confirm"],
    func: () => checkoutApi.confirmCheckout(),
    options: {
      onSuccess: (data) => onSuccess(data.orderId),
      onError,
    },
  })
}
export default useCheckoutConfirm
