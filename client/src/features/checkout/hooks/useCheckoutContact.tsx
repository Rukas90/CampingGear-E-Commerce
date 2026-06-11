import type { CheckoutContact } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useCheckoutContext, useCheckoutSection, useData } from "@features"

const useCheckoutContact = () => {
  const { form, isPending, errors } = useCheckoutContext()

  const data = useData<CheckoutContact>({
    data: form?.contact,
    defaultData: {
      emailAddress: "",
    },
    mutationKey: ["checkout-contact"],
    requestFunc: checkoutApi.updateContact,
    errorKeyMappers: [(key) => key, (key) => `contact.${key}`],
    errorPool: errors,
    onMutationSuccess: () => section.close(),
  })
  const section = useCheckoutSection({
    name: "contact",
    data: data,
  })

  return {
    data,
    section,
    isPending,
    isMutating: data.isMutating,
    isBusy: isPending || data.isMutating,
  }
}
export default useCheckoutContact
