import { HandleReqFn } from "@lib"
import { useQuery, type UseQueryOptions } from "@tanstack/react-query"
import type { ApiResult } from "@types"

export interface QueryOptions {
  enabled?: boolean
}
interface QueryHandlerData<
  TQueryKey extends readonly unknown[],
  TResult,
> extends Omit<UseQueryOptions<TResult>, "queryKey" | "queryFn"> {
  key: TQueryKey
  func: () => Promise<ApiResult<TResult>>
}

const useQueryHandler = <TQueryKey extends readonly unknown[], TResult>({
  key,
  func,
  ...options
}: QueryHandlerData<TQueryKey, TResult>) => {
  return useQuery({
    queryKey: key,
    queryFn: () => HandleReqFn(() => func()),
    ...options,
  })
}
export default useQueryHandler
