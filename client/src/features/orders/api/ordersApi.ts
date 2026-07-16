import { makeRequest } from "@lib"
import type { OrderId, OrderDetails, OrderSummary } from "@types"

const ordersApi = {
  get: (id: OrderId) => makeRequest<OrderDetails>(`api/v1/orders/${id}`),
  getOrders: () => makeRequest<OrderSummary[]>(`api/v1/orders`),
}
export default ordersApi
