import { useQueryHandler, type QueryOptions } from "@features"
import checkoutApi from "../api/checkoutApi"

const useCheckout = (options?: QueryOptions) => {
  return useQueryHandler({
    key: ["checkout"],
    func: () => checkoutApi.checkout(),
    options,
  })
}
export default useCheckout
