import { type QueryOptions } from "@features"
import checkoutApi from "../api/checkoutApi"
import { useQuery } from "@tanstack/react-query"
import { HandleReqFn } from "@lib"

const useCheckoutForm = (options?: QueryOptions) => {
  const query = useQuery({
    queryKey: ["checkout-form"],
    queryFn: () => HandleReqFn(() => checkoutApi.getForm()),
    ...options,
  })

  return { form: query.data, ...query }
}
export default useCheckoutForm
