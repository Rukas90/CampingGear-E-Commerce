import { makeRequest } from "@lib"
import type { OrderSummary, OrderToken } from "@types"

const ordersApi = {
  get: async (token: OrderToken) => {
    return await makeRequest<OrderSummary>(`api/v1/orders/${token}`)
  },
}
export default ordersApi
