import type { CustomerAccount, ProblemDetails } from "@types"
import { useCallback, useRef } from "react"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import { useMutation } from "@tanstack/react-query"
import useAccount from "./useAccount"

export type AuthRefreshData = {
  execute: () => Promise<CustomerAccount>
  canRefresh: React.RefObject<boolean>
  promise: Promise<CustomerAccount> | null
  reset: () => void
  block: () => void
}

const useAuthRefresh = (): AuthRefreshData => {
  const { setAccount } = useAccount()
  const canRefreshRef = useRef(true)
  const refreshPromiseRef = useRef<Promise<CustomerAccount> | null>(null)

  const { mutateAsync } = useMutation<CustomerAccount, ProblemDetails>({
    mutationFn: () => HandleReqFn(() => authApi.refresh()),
    onSuccess: (account) => {
      setAccount(account)
      canRefreshRef.current = true
    },
    onError: () => {
      setAccount(null)
      canRefreshRef.current = false
    },
    onSettled: () => {
      refreshPromiseRef.current = null
    },
  })

  const execute = useCallback(() => {
    if (refreshPromiseRef.current) return refreshPromiseRef.current
    refreshPromiseRef.current = mutateAsync()
    return refreshPromiseRef.current
  }, [mutateAsync])

  const reset = useCallback(() => {
    canRefreshRef.current = true
  }, [])

  const block = useCallback(() => {
    canRefreshRef.current = false
  }, [])

  return {
    execute,
    canRefresh: canRefreshRef,
    promise: refreshPromiseRef.current,
    reset,
    block,
  }
}
export default useAuthRefresh
