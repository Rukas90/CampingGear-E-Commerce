import type { ProblemDetails } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useMutateHandler } from "@features"

const useCheckoutConfirm = ({
  onError,
}: {
  onError: (problem: ProblemDetails) => void
}) => {
  return useMutateHandler({
    key: ["checkout-confirm"],
    func: () => checkoutApi.confirmCheckout(),
    options: {
      onError,
    },
  })
}
export default useCheckoutConfirm
