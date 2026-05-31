import type { ApiResult } from "@types"

export const ApiOk = <T>(data: T): ApiResult<T> => {
  return {
    isSuccess: true,
    data,
  }
}
