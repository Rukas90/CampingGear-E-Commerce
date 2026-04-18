export const API_URL = import.meta.env.VITE_API_URL

export const makeRequest = async <T>(path: string): Promise<ApiResult<T>> => {
  const url = `${API_URL}/${path.replace(/^\//, "")}`

  try {
    const response = await fetch(url)

    if (response.ok) {
      return {
        isSuccess: true,
        data: (await response.json()) as T,
      }
    }
    return {
      isSuccess: false,
      error: (await response.json()) as ProblemDetails,
    }
  } catch {
    return {
      isSuccess: false,
      error: {
        title: "Network error",
      },
    }
  }
}

export type ApiResult<T> = {
  isSuccess: boolean
  data?: T
  error?: ProblemDetails
}

export type ProblemDetails = {}
