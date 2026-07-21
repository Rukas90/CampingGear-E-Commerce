import type { CustomerAccount, ProblemDetails } from "@types"
import { useCallback, useRef, useState } from "react"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import { useMutation } from "@tanstack/react-query"
import useAccount from "./useAccount"

type LastRefreshResult = "None" | "Success" | "Failed"

const useAuthRefresh = () => {
  const { setAccount } = useAccount()
  const [lastRefresh, setLastRefresh] = useState<LastRefreshResult>("None")

  const refreshPromiseRef = useRef<Promise<CustomerAccount> | null>(null)

  const { mutateAsync } = useMutation<CustomerAccount, ProblemDetails>({
    mutationFn: () => HandleReqFn(() => authApi.refresh()),
    onSuccess: (account) => {
      setAccount(account)
      setLastRefresh("Success")
    },
    onError: () => {
      setAccount(null)
      setLastRefresh("Failed")
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
    lastRefresh,
    promise: refreshPromiseRef.current,
  }
}
export default useAuthRefresh
