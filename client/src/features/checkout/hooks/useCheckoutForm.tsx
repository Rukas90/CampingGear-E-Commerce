import { useQueryHandler, type QueryOptions } from "@features"
import checkoutApi from "../api/checkoutApi"

const useCheckoutForm = (options?: QueryOptions) => {
  const query = useQueryHandler({
    key: ["checkout-form"],
    func: () => checkoutApi.getForm(),
    options,
  })

  return { form: query.data, ...query }
}
export default useCheckoutForm
