import { HandleReqFn } from "@lib"
import { useMutation } from "@tanstack/react-query"
import type { ApiResult, ProblemDetails } from "@types"

export interface MutateOptions<TResult> {
  onSuccess?: (data: TResult) => void
  onError?: (error: ProblemDetails) => void
  onSettled?: (data: TResult | undefined, error: ProblemDetails | null) => void
  onMutate?: () => void
}
interface MutateHandlerData<TMutateKey, TResult> {
  key: TMutateKey[]
  func: () => Promise<ApiResult<TResult>>
  options?: MutateOptions<TResult>
}
const useMutateHandler = <TQueryKey, TResult>({
  key,
  func,
  options,
}: MutateHandlerData<TQueryKey, TResult>) => {
  return useMutation<TResult, ProblemDetails>({
    mutationKey: key,
    mutationFn: () => HandleReqFn(() => func()),
    onSuccess: options?.onSuccess,
    onError: options?.onError,
    onSettled: options?.onSettled,
    onMutate: options?.onMutate,
  })
}
export default useMutateHandler
