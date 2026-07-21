import { useMutation } from "@tanstack/react-query"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import type { ProblemDetails } from "@types"
import { useAuth } from "../contexts/AuthContext"
import useAccount from "./useAccount"

const useLogout = (opts?: {
  onSuccess?: () => void
  onError?: (p: ProblemDetails) => void
}) => {
  const { setAccount } = useAccount()
  const { refresh } = useAuth()

  return useMutation<unknown, ProblemDetails>({
    mutationFn: async () => {
      refresh.block()
      setAccount(null)
      return HandleReqFn(() => authApi.logout())
    },
    onSuccess: opts?.onSuccess,
    onError: opts?.onError,
  })
}

export default useLogout
