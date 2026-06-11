import { HandleReqFn } from "@lib"
import { useQuery, useQueryClient } from "@tanstack/react-query"
import type { CustomerAccount, ProblemDetails } from "@types"
import { authApi } from "../api"

const useAccount = () => {
  const queryClient = useQueryClient()

  const query = useQuery<CustomerAccount | null, ProblemDetails>({
    queryKey: ["account"],
    queryFn: () => HandleReqFn(() => authApi.me()),
    retry: false,
    staleTime: 5 * 60 * 1000,
  })

  const setAccount = (account: CustomerAccount | null) => {
    queryClient.setQueryData(["account"], account)
  }

  return {
    account: query.data,
    isLoggedIn: query.data !== null,
    ...query,
    setAccount,
  }
}
export default useAccount
