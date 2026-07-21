import { useMutation } from "@tanstack/react-query"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import type { ProblemDetails } from "@types"
import { useAuth } from "../contexts/AuthContext"
import useAccount from "./useAccount"
import { useSession } from "@features"

const useLogout = (opts?: {
  onSuccess?: () => void
  onError?: (p: ProblemDetails) => void
}) => {
  const { setAccount } = useAccount()
  const { refresh } = useAuth()
  const { invalidate } = useSession()

  return useMutation<unknown, ProblemDetails>({
    mutationFn: async () => {
      refresh.block()
      setAccount(null)
      return HandleReqFn(() => authApi.logout())
    },
    onSuccess: async () => {
      await invalidate()
      opts?.onSuccess
    },
    onError: opts?.onError,
  })
}

export default useLogout
