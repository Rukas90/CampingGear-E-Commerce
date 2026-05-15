import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { ApiResult } from "@types"

export interface QueryOptions {
  enabled?: boolean
}
interface QueryHandlerData<TQueryKey, TResult> {
  key: TQueryKey[]
  func: () => Promise<ApiResult<TResult>>
  options?: QueryOptions
}
const useQueryHandler = <TQueryKey, TResult>({
  key,
  func,
  options,
}: QueryHandlerData<TQueryKey, TResult>) => {
  return useQuery({
    queryKey: key,
    queryFn: () => handleQueryFn(() => func()),
    enabled: options?.enabled ?? true,
  })
}
export default useQueryHandler
