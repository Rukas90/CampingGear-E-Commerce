import { useQueryHandler, type QueryOptions } from "@features"
import sessionApi from "../api/sessionApi"
import { useQueryClient } from "@tanstack/react-query"

const useSessionSummary = (options?: QueryOptions) => {
  const queryClient = useQueryClient()

  const query = useQueryHandler({
    key: ["session-summary"],
    func: () => sessionApi.getSessionSummary(),
    ...options,
  })

  const invalidate = async () => {
    await queryClient.invalidateQueries({ queryKey: ["session-summary"] })
    await queryClient.invalidateQueries({ queryKey: ["cart"] })
  }

  return {
    summary: query.data ?? {
      cartCount: 0,
      wishlistCount: 0,
    },
    invalidate,
    ...query,
  }
}
export default useSessionSummary
