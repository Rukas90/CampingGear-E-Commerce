import { reqToParams } from "@features"
import { makeRequest } from "@lib"
import type { CartSku, GetCartSkusRequest } from "@types"

const cartApi = {
  getCartSkus: async (request: GetCartSkusRequest) =>
    await makeRequest<CartSku[]>(
      `api/v1/cart/skus?${reqToParams(request).toString()}`,
    ),
}
export default cartApi
