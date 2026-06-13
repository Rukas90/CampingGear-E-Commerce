import type { ProblemDetails } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useMutateHandler } from "@features"

const useCheckoutConfirm = ({
  onSuccess,
  onError,
}: {
  onSuccess: (token: string) => void
  onError: (problem: ProblemDetails) => void
}) => {
  return useMutateHandler({
    key: ["checkout-confirm"],
    func: () => checkoutApi.confirmCheckout(),
    options: {
      onSuccess: (data) => onSuccess(data.orderToken),
      onError,
    },
  })
}
export default useCheckoutConfirm
