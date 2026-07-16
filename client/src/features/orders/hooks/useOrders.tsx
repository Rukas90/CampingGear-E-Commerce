import { useQuery } from "@tanstack/react-query"
import ordersApi from "../api/ordersApi"
import { HandleReqFn } from "@lib"

const useOrders = () => {
  const query = useQuery({
    queryKey: ["orders"],
    queryFn: () => HandleReqFn(() => ordersApi.getOrders()),
  })

  return { orders: query.data, ...query }
}
export default useOrders
