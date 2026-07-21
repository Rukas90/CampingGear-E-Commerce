import { useLayoutEffect } from "react"
import { AuthErrorCodes } from "../errors"
import { client } from "@lib"
import type { ProblemDetails } from "@types"
import useAuthRefresh from "./useAuthRefresh"
import useAccount from "./useAccount"

const isUnauthenticated = (data: ProblemDetails) =>
  data?.status === 401 &&
  data?.errors?.[0]?.code === AuthErrorCodes.AUTH_UNAUTHENTICATED

const useAuthInterceptor = () => {
  const { lastRefresh, refresh } = useAuthRefresh()
  const { isLoggedIn } = useAccount()

  useLayoutEffect(() => {
    const interceptorId = client.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config

        if (originalRequest._retry) {
          return Promise.reject(error)
        }

        const isUnauthenticatedResponse = isUnauthenticated(
          error.response?.data,
        )

        if (
          !isUnauthenticatedResponse ||
          (isUnauthenticatedResponse && !isLoggedIn) ||
          lastRefresh === "Failed"
        ) {
          return Promise.reject(error)
        }

        try {
          await refresh()
          originalRequest._retry = true
          await new Promise((r) => setTimeout(r, 10))
          return client(originalRequest)
        } catch {
          return Promise.reject(error)
        }
      },
    )
    return () => client.interceptors.response.eject(interceptorId)
  }, [refresh])
}
export default useAuthInterceptor
