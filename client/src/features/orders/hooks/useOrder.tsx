import { useQuery } from "@tanstack/react-query"
import ordersApi from "../api/ordersApi"
import { HandleReqFn } from "@lib"
import type { OrderToken } from "@types"

const useOrder = (token: OrderToken) => {
  const query = useQuery({
    queryKey: ["orders", token],
    queryFn: () => HandleReqFn(() => ordersApi.get(token)),
  })

  return { order: query.data, ...query }
}
export default useOrder
