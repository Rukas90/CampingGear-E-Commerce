import { type OrderId, type ProblemDetails } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useMutation } from "@tanstack/react-query"
import { HandleReqFn } from "@lib"

const useCheckoutConfirm = ({
  onSuccess,
  onError,
}: {
  onSuccess: (id: OrderId) => void
  onError: (problem: ProblemDetails) => void
}) => {
  return useMutation({
    mutationKey: ["checkout-confirm"],
    mutationFn: (saveInformation: boolean) =>
      HandleReqFn(() => checkoutApi.confirmCheckout(saveInformation)),
    onSuccess: (data) => onSuccess(data.orderId),
    onError,
  })
}
export default useCheckoutConfirm
