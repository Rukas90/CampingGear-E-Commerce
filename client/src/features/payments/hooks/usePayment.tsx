import { HandleReqFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import paymentsApi from "@features/payments/api/paymentsApi"

const usePayment = (referenceId?: string) => {
  const query = useQuery({
    queryKey: ["payment", referenceId],
    queryFn: () => HandleReqFn(() => paymentsApi.get(referenceId!)),
    enabled: !!referenceId,
    staleTime: Infinity,
    retry: false,
  })

  return { payment: query.data ?? null, ...query }
}
export default usePayment
