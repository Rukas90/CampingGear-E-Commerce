import {
  useCheckoutContext,
  useCheckoutSection,
  useCheckoutStats,
  useCountryShippingMethods,
  useData,
} from "@features"
import type { CheckoutShipping, PostalAddress, ShippingMethodId } from "@types"
import { DEFAULT_ADDRESS } from "@lib"
import checkoutApi from "../api/checkoutApi"

const useCheckoutShipping = () => {
  const { form, isPending, errors } = useCheckoutContext()
  const { invalidate } = useCheckoutStats()

  const addressData = useData<PostalAddress, PostalAddress, CheckoutShipping>({
    data: form?.shipping.address,
    defaultData: DEFAULT_ADDRESS,
    mutationKey: ["checkout-shipping-address"],
    requestFunc: checkoutApi.updateShippingAddress,
    onMutationSuccess: (checkoutShipping) => {
      addressSection.close()

      if (checkoutShipping) {
        methodData.overrideData(checkoutShipping.selectedMethodId)
        invalidate()
      }
    },
    errorKeyMappers: [(key) => key, (key) => `shipping_address.${key}`],
    errorPool: errors,
  })
  const addressSection = useCheckoutSection({
    name: "shipping_address",
    data: addressData,
  })

  const methodData = useData<
    ShippingMethodId | undefined,
    ShippingMethodId,
    string
  >({
    data: form?.shipping.selectedMethodId,
    defaultData: undefined,
    mutationKey: ["checkout-shipping-method"],
    requestFunc: checkoutApi.updateShippingMethod,
    onMutationSuccess: () => {
      methodSection.close()
      invalidate()
    },
    errorKeyMappers: [(key) => key, (key) => `shipping_method.${key}`],
    errorPool: errors,
  })
  const methodSection = useCheckoutSection({
    name: "shipping_method",
    data: methodData,
  })

  const countryCode =
    addressData.cachedResponse?.address?.countryCode ??
    form?.shipping?.address?.countryCode

  const { availableMethods } = useCountryShippingMethods(countryCode, {
    enabled: !!countryCode,
  })

  return {
    address: {
      ...addressData,
      ...addressSection,
    },
    availableMethods,
    method: {
      ...methodData,
      ...methodSection,
    },
    isPending,
    isBusy: isPending || addressData.isMutating || methodData.isMutating,
  }
}
export default useCheckoutShipping
