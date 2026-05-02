import type { ApiResult } from "@types"

const handleQueryFn = async <T>(
  fn: () => Promise<ApiResult<T>>,
): Promise<T> => {
  const result = await fn()
  if (!result.isSuccess) throw result.error
  return result.data!
}
export default handleQueryFn
