import { useLayoutEffect } from "react"
import { AuthErrorCodes } from "../errors"
import { client } from "@lib"
import type { ProblemDetails } from "@types"
import useAuthRefresh from "./useAuthRefresh"

const isUnauthenticated = (data: ProblemDetails) =>
  data?.status === 401 &&
  data?.errors?.[0]?.code === AuthErrorCodes.AUTH_UNAUTHENTICATED

const useAuthInterceptor = () => {
  const { refresh } = useAuthRefresh()

  useLayoutEffect(() => {
    const interceptorId = client.interceptors.response.use(
      (response) => response,
      async (error) => {
        const originalRequest = error.config

        if (originalRequest._retry) {
          return Promise.reject(error)
        }
        if (!isUnauthenticated(error.response?.data)) {
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
