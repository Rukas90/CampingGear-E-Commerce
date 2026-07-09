import { HandleReqFn } from "@lib"
import ordersApi from "../api/ordersApi"
import type { OrderToken } from "@types"
import { useQuery } from "@tanstack/react-query"

const usePayment = (token?: OrderToken) => {
  const query = useQuery({
    queryKey: ["payment", token],
    queryFn: () => HandleReqFn(() => ordersApi.issuePayment(token!)),
    enabled: !!token,
    staleTime: Infinity,
    retry: false,
  })

  return { payment: query.data ?? null, ...query }
}
export default usePayment
