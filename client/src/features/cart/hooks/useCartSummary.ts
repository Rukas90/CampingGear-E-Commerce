import { useQueryHandler, type QueryOptions } from "@features"
import cartApi from "../api/cartApi"

const useCartSummary = (options?: QueryOptions) => {
  const query = useQueryHandler({
    key: ["cart-summary"],
    func: () => cartApi.getSummary(),
    ...options,
  })

  return { summary: query.data, ...query }
}
export default useCartSummary
