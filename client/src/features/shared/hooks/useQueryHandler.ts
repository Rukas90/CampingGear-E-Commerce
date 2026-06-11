import { HandleReqFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { ApiResult } from "@types"

export interface QueryOptions {
  enabled?: boolean
}
interface QueryHandlerData<TQueryKey, TResult> {
  key: TQueryKey[]
  func: () => Promise<ApiResult<TResult>>
  options?: QueryOptions
  select?: (data: TResult) => TResult
}
const useQueryHandler = <TQueryKey, TResult>({
  key,
  func,
  options,
  select,
}: QueryHandlerData<TQueryKey, TResult>) => {
  return useQuery({
    queryKey: key,
    queryFn: () => HandleReqFn(() => func()),
    enabled: options?.enabled ?? true,
    select,
  })
}
export default useQueryHandler
