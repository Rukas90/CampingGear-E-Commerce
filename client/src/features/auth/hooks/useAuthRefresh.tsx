import type { CustomerAccount, ProblemDetails } from "@types"
import { useCallback, useRef } from "react"
import { authApi } from "../api"
import { handleQueryFn } from "@lib"
import { useMutation } from "@tanstack/react-query"
import useAccount from "./useAccount"

const useAuthRefresh = () => {
  const { setAccount } = useAccount()

  const refreshPromiseRef = useRef<Promise<CustomerAccount> | null>(null)

  const { mutateAsync } = useMutation<CustomerAccount, ProblemDetails>({
    mutationFn: () => handleQueryFn(() => authApi.refresh()),
    onSuccess: (account) => {
      setAccount(account)
    },
    onError: () => {
      setAccount(null)
    },
    onSettled: () => {
      refreshPromiseRef.current = null
    },
  })

  const refresh = useCallback(() => {
    if (refreshPromiseRef.current) {
      return refreshPromiseRef.current
    }
    refreshPromiseRef.current = mutateAsync()
    return refreshPromiseRef.current
  }, [setAccount])

  return {
    refresh,
    promise: refreshPromiseRef.current,
  }
}
export default useAuthRefresh
