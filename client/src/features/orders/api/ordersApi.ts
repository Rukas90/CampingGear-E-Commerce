import { makeRequest } from "@lib"
import type { OrderPayment, OrderSummary, OrderToken } from "@types"

const ordersApi = {
  get: async (token: OrderToken) => {
    return await makeRequest<OrderSummary>(`api/v1/orders/${token}`)
  },
  issuePayment: async (token: OrderToken) => {
    return await makeRequest<OrderPayment>(`api/v1/orders/payment`, "post", {
      token: token,
    })
  },
}
export default ordersApi
