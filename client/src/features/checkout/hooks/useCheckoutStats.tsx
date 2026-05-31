import { useQueryHandler, type QueryOptions } from "@features"
import checkoutApi from "../api/checkoutApi"
import { useQueryClient } from "@tanstack/react-query"

const useCheckoutStats = (options?: QueryOptions) => {
  const queryClient = useQueryClient()

  const query = useQueryHandler({
    key: ["checkout-stats"],
    func: () => checkoutApi.getStats(),
    options,
  })

  const invalidate = () =>
    queryClient.invalidateQueries({
      queryKey: ["checkout-stats"],
    })

  return {
    stats: query.data,
    invalidate,
    ...query,
  }
}
export default useCheckoutStats
