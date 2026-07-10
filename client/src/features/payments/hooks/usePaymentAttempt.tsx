import { HandleReqFn } from "@lib"
import { useMutation } from "@tanstack/react-query"
import paymentsApi from "@features/payments/api/paymentsApi"
import type { PaymentId } from "@types"

const usePaymentAttempt = (paymentId: PaymentId) => {
  const mutation = useMutation({
    mutationKey: ["payment-attempt", paymentId],
    mutationFn: () => HandleReqFn(() => paymentsApi.issueAttempt(paymentId)),
    retry: false,
  })

  return {
    attempt: mutation.data ?? null,
    issueAsync: mutation.mutateAsync,
    ...mutation,
  }
}
export default usePaymentAttempt
