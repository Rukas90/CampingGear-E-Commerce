import { useQuery } from "@tanstack/react-query"
import ordersApi from "../api/ordersApi"
import { HandleReqFn } from "@lib"
import type { OrderId } from "@types"

const useOrder = (id?: OrderId) => {
  const query = useQuery({
    queryKey: ["orders", id],
    queryFn: () => HandleReqFn(() => ordersApi.get(id!)),
    enabled: !!id,
  })

  return { order: query.data, ...query }
}
export default useOrder
