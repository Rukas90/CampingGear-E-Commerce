import { useLayoutEffect, useRef } from "react"
import { AuthErrorCodes } from "../errors"
import { client } from "@lib"
import type { ProblemDetails } from "@types"
import { type AuthRefreshData } from "./useAuthRefresh"

const isUnauthenticated = (data: ProblemDetails) =>
  data?.status === 401 &&
  data?.errors?.[0]?.code === AuthErrorCodes.AUTH_UNAUTHENTICATED

interface AuthInterceptorProps {
  refresh: AuthRefreshData
}

const useAuthInterceptor = ({ refresh }: AuthInterceptorProps) => {
  const refreshRef = useRef(refresh)
  refreshRef.current = refresh

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

        if (!isUnauthenticatedResponse || !refreshRef.current.canRefresh) {
          return Promise.reject(error)
        }

        try {
          await refresh.execute()
          originalRequest._retry = true
          await new Promise((r) => setTimeout(r, 10))
          return client(originalRequest)
        } catch {
          return Promise.reject(error)
        }
      },
    )
    return () => client.interceptors.response.eject(interceptorId)
  }, [])
}
export default useAuthInterceptor
