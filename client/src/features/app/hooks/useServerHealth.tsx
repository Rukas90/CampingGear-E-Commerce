import { useQuery } from "@tanstack/react-query"
import appApi from "../api/AppApi"

const useServerHealth = () => {
  return useQuery({
    queryKey: ["server", "health"],
    queryFn: async () => {
      const res = await appApi.health()
      if (!res.isSuccess) {
        throw res.error
      }

      return res.data
    },
    retry: true,
    retryDelay: 10000,
    staleTime: Infinity,
  })
}
export default useServerHealth
