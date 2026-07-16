import { HandleReqFn } from "@lib"
import { useQuery, useQueryClient } from "@tanstack/react-query"
import type { CustomerAccount, ProblemDetails } from "@types"
import { authApi } from "../api"
import { useSession } from "@features"

const useAccount = () => {
  const queryClient = useQueryClient()
  const { invalidate } = useSession()
  const query = useQuery<CustomerAccount | null, ProblemDetails>({
    queryKey: ["account"],
    queryFn: () => HandleReqFn(() => authApi.me()),
    retry: false,
    staleTime: 5 * 60 * 1000,
  })

  const setAccount = (account: CustomerAccount | null) => {
    queryClient.setQueryData(["account"], account)
  }

  const signOut = async () => {
    const result = await authApi.logout()

    if (result.isSuccess) {
      setAccount(null)
    }

    await invalidate()
  }

  return {
    account: query.data,
    isLoggedIn: query.data !== null,
    signOut,
    ...query,
    setAccount,
  }
}
export default useAccount
