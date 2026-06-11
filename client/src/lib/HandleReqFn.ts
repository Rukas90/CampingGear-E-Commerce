import type { ApiResult } from "@types"

const HandleReqFn = async <T>(fn: () => Promise<ApiResult<T>>): Promise<T> => {
  const result = await fn()
  if (!result.isSuccess) throw result.error
  return result.data!
}
export default HandleReqFn
