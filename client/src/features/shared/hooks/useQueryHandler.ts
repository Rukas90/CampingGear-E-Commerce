import { HandleReqFn } from "@lib"
import { useQuery, type UseQueryOptions } from "@tanstack/react-query"
import type { ApiResult, ProblemDetails } from "@types"
import { useEffect } from "react"

export interface QueryOptions {
  enabled?: boolean
}
interface QueryHandlerData<
  TQueryKey extends readonly unknown[],
  TResult,
> extends Omit<
  UseQueryOptions<TResult, ProblemDetails, TResult, TQueryKey>,
  "queryKey" | "queryFn"
> {
  key: TQueryKey
  func: () => Promise<ApiResult<TResult>>
  onError?: (error: ProblemDetails) => void
}

const useQueryHandler = <TQueryKey extends readonly unknown[], TResult>({
  key,
  func,
  onError,
  ...options
}: QueryHandlerData<TQueryKey, TResult>) => {
  const query = useQuery<TResult, ProblemDetails, TResult, TQueryKey>({
    queryKey: key,
    queryFn: () => HandleReqFn<TResult>(() => func()),
    ...options,
  })

  useEffect(() => {
    if (query.error) {
      onError?.(query.error)
    }
  }, [query.error])

  return query
}
export default useQueryHandler
