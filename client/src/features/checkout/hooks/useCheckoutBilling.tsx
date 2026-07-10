import type { CheckoutBilling } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useCheckoutContext, useCheckoutSection, useData } from "@features"

const useCheckoutBilling = () => {
  const { form, isPending, errors } = useCheckoutContext()

  const data = useData<CheckoutBilling>({
    data: form?.billing,
    defaultData: {
      address: undefined,
      asShippingAddress: true,
    },
    mutationKey: ["checkout-billing"],
    requestFunc: checkoutApi.updateBilling,
    errorKeyMappers: [(key) => key, (key) => `billing_address.${key}`],
    errorPool: errors,
  })
  const section = useCheckoutSection({
    name: "billing",
    data: data,
  })

  return {
    billing: {
      ...data,
      ...section,
    },
    isPending,
    isMutating: data.isMutating,
    isBusy: isPending || data.isMutating,
  }
}
export default useCheckoutBilling
