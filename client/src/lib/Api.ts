import type { ApiResult, ProblemDetails } from "@types"
import axios, { type AxiosInstance } from "axios"
import Cookies from "js-cookie"

export const API_URL = import.meta.env.VITE_API_URL

export const client: AxiosInstance = axios.create({
  baseURL: API_URL,
  withCredentials: true,
})

const CSRF_COOKIE_NAME = "csrf_token" as const
const CSRF_HEADER_NAME = "X-Csrf-Token" as const

client.interceptors.request.use(async (request) => {
  const csrfCookie = Cookies.get(CSRF_COOKIE_NAME)

  if (!!csrfCookie) {
    request.headers[CSRF_HEADER_NAME] = csrfCookie
  }
  return request
})

export const makeRequest = async <T>(
  path: string,
  method: "get" | "post" | "put" | "delete" = "get",
  body?: unknown,
): Promise<ApiResult<T>> => {
  try {
    const response = await client.request<T>({ url: path, method, data: body })

    return {
      isSuccess: true,
      data: response.data,
    }
  } catch (error) {
    if (axios.isAxiosError(error) && error.response?.status === 429) {
      return {
        isSuccess: false,
        error: {
          type: "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
          title: "Too Many Requests",
          status: 429,
          errors: [
            {
              name: "Too Many Requests",
              code: "client.too_many_requests",
              reason: "Too many requests. Please try again later.",
            },
          ],
        },
      }
    }
    if (axios.isAxiosError(error) && error.response) {
      return {
        isSuccess: false,
        error: error.response.data as ProblemDetails,
      }
    }
    if (axios.isAxiosError(error) && !error.response) {
      return {
        isSuccess: false,
        error: {
          type: "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
          title: "Network Error",
          status: 500,
          errors: [
            {
              name: "Network Error",
              code: "client.network_error",
              reason: "Could not make the request due to network issues.",
            },
          ],
        },
      }
    }
    return {
      isSuccess: false,
      error: {
        type: "https://www.rfc-editor.org/rfc/rfc7231#section-6.5.1",
        title: "Unexpected Error",
        status: 500,
        errors: [
          {
            name: "Unexpected Error",
            code: "client.unknown_error",
            reason: "An unexpected error occurred. Please try again.",
          },
        ],
      },
    }
  }
}
