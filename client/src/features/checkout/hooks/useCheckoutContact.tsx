import useCheckoutForm from "./useCheckoutForm"
import type { CheckoutContact } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useData } from "@features"

const useCheckoutContact = () => {
  const { form, isPending } = useCheckoutForm()

  const data = useData<CheckoutContact>({
    data: form?.contact,
    defaultData: {
      emailAddress: "",
    },
    mutationKey: ["checkout-contact"],
    requestFunc: checkoutApi.updateContact,
  })

  return {
    data,
    isPending,
    isMutating: data.isMutating,
    isBusy: isPending || data.isMutating,
  }
}
export default useCheckoutContact
