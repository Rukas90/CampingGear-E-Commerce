import { useMutation } from "@tanstack/react-query"
import type { LoginData } from "../schemas"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import type { CustomerAccount, ProblemDetails } from "@types"
import useAccount from "./useAccount"
import { useAuth } from "../contexts/AuthContext"
import { useSession } from "@features"

const useLogin = (opts?: {
  onSuccess?: (a: CustomerAccount) => void
  onError?: (p: ProblemDetails) => void
}) => {
  const { setAccount } = useAccount()
  const { refresh } = useAuth()
  const { invalidate } = useSession()

  return useMutation<CustomerAccount, ProblemDetails, LoginData>({
    mutationFn: (data) => HandleReqFn(() => authApi.login(data)),
    onSuccess: async (account) => {
      setAccount(account)
      refresh.reset()
      await invalidate()

      opts?.onSuccess?.(account)
    },
    onError: opts?.onError,
  })
}
export default useLogin
