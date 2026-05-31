import { useQueryHandler, type QueryOptions } from "@features"
import checkoutApi from "../api/checkoutApi"

const useCheckout = (options?: QueryOptions) => {
  return useQueryHandler({
    key: ["checkout"],
    func: () => checkoutApi.init(),
    options,
  })
}
export default useCheckout
