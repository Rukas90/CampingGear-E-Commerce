import { makeRequest } from "@lib"
import type {
  Payment,
  PaymentAttempt,
  PaymentAttemptId,
  PaymentAttemptStatus,
  PaymentId,
} from "@types"

const paymentsApi = {
  get: (referenceId: string) =>
    makeRequest<Payment>(`api/v1/payments/${referenceId}`),

  issueAttempt: (paymentId: PaymentId) =>
    makeRequest<PaymentAttempt>(`api/v1/payments/attempts`, "post", {
      PaymentId: paymentId,
    }),

  getAttemptStatus: (id: PaymentAttemptId) =>
    makeRequest<PaymentAttemptStatus>(`api/v1/payments/attempts/${id}`),

  cancel: (paymentId: PaymentId) =>
    makeRequest<PaymentAttempt>(`api/v1/payments/cancel`, "post", {
      PaymentId: paymentId,
    }),
}
export default paymentsApi
