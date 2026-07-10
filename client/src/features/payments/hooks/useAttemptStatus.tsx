import { HandleReqFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { PaymentAttemptId } from "@types"
import paymentsApi from "../api/paymentsApi"

const useAttemptStatus = (attemptId: PaymentAttemptId) => {
  const query = useQuery({
    queryKey: ["payment-attempt", "status", attemptId],
    queryFn: () => HandleReqFn(() => paymentsApi.getAttemptStatus(attemptId)),
  })

  return { attempt: query.data, ...query }
}
export default useAttemptStatus
