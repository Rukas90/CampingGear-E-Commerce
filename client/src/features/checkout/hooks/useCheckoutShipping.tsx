import { useCheckoutStats, useCountryShippingMethods, useData } from "@features"
import useCheckoutForm from "./useCheckoutForm"
import type { CheckoutShipping, PostalAddress, ShippingMethodId } from "@types"
import { DEFAULT_ADDRESS } from "@lib"
import checkoutApi from "../api/checkoutApi"

const useCheckoutShipping = () => {
  const { form, isPending } = useCheckoutForm()
  const { invalidate } = useCheckoutStats()

  const address = useData<PostalAddress, CheckoutShipping>({
    data: form?.shipping.address,
    defaultData: DEFAULT_ADDRESS,
    mutationKey: ["checkout-shipping-address"],
    requestFunc: checkoutApi.updateShippingAddress,
    onMutationSuccess: (checkoutShipping) => {
      if (checkoutShipping) {
        method.overrideData(checkoutShipping.selectedMethodId)
        invalidate()
      }
    },
  })

  const countryCode =
    address.cachedResponse?.address?.countryCode ??
    form?.shipping?.address?.countryCode

  const { availableMethods } = useCountryShippingMethods(countryCode, {
    enabled: !!countryCode,
  })

  const method = useData<ShippingMethodId | undefined>({
    data: form?.shipping.selectedMethodId,
    defaultData: undefined,
    mutationKey: ["checkout-shipping-method"],
    requestFunc: checkoutApi.updateShippingMethod,
    onMutationSuccess: () => {
      invalidate()
    },
  })

  return {
    address,
    availableMethods,
    method,
    isPending,
    isBusy: isPending || address.isMutating || method.isMutating,
  }
}
export default useCheckoutShipping
