import useCheckoutForm from "./useCheckoutForm"
import type { CheckoutBilling } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useData } from "@features"

const useCheckoutBilling = () => {
  const { form, isPending } = useCheckoutForm()

  const data = useData<CheckoutBilling>({
    data: form?.billing,
    defaultData: {
      address: undefined,
      asShippingAddress: true,
    },
    mutationKey: ["checkout-billing"],
    requestFunc: checkoutApi.updateBilling,
  })

  return {
    data,
    isPending,
    isMutating: data.isMutating,
    isBusy: isPending || data.isMutating,
  }
}
export default useCheckoutBilling
