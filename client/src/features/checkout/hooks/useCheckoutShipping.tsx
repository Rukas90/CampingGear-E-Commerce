import { useData } from "@features"
import useCheckoutForm from "./useCheckoutForm"
import type { PostalAddress } from "@types"
import { DEFAULT_ADDRESS } from "@lib"
import checkoutApi from "../api/checkoutApi"

const useCheckoutShipping = () => {
  const { form, isPending } = useCheckoutForm()

  const data = useData<PostalAddress>({
    data: form?.shippingAddress,
    defaultData: DEFAULT_ADDRESS,
    mutationKey: ["checkout-shipping"],
    requestFunc: checkoutApi.updateShipping,
  })

  return {
    data,
    isPending,
    isMutating: data.isMutating,
    isBusy: isPending || data.isMutating,
  }
}
export default useCheckoutShipping
