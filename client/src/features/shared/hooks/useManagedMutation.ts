import { useMutation } from "@tanstack/react-query"
import type { ApiResult, ProblemDetails } from "@types"
import { useFormErrors } from "./useFormErrors"

interface UseManagedMutationProps<TData, TResponse> {
  mutationKey: string[]
  requestFunc: (data: TData) => Promise<ApiResult<TResponse>>
  onSuccess?: (response: TResponse | undefined) => void
  onError?: () => void
}

export const useManagedMutation = <TData, TResponse = unknown>({
  mutationKey,
  requestFunc,
  onSuccess,
  onError,
}: UseManagedMutationProps<TData, TResponse>) => {
  const errors = useFormErrors()
  const mutation = useMutation<TResponse | undefined, ProblemDetails, TData>({
    mutationKey,
    mutationFn: async (payload) => {
      const result = await requestFunc(payload)
      if (result.isSuccess) return result.data
      throw result.error
    },
    onError: (problemDetails) => {
      errors.setFromProblemDetails(problemDetails.errors)
      onError?.()
    },
    onSuccess: (response) => {
      errors.clear()
      onSuccess?.(response)
    },
  })

  const commitWith = (snapshot: TData) => {
    if (mutation.isPending) return
    mutation.mutateAsync(snapshot)
  }

  return { commitWith, isPending: mutation.isPending, errors }
}
