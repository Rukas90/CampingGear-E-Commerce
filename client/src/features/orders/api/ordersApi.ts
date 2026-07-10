import { makeRequest } from "@lib"
import type { OrderId, OrderSummary } from "@types"

const ordersApi = {
  get: async (id: OrderId) => {
    return await makeRequest<OrderSummary>(`api/v1/orders/${id}`)
  },
}
export default ordersApi
