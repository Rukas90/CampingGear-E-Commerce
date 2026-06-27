import { makeRequest } from "@lib"
import type { CartItem, CartItemId, SkuId } from "@types"

const cartApi = {
  addToCart: async (skuId: SkuId, quantity: number) =>
    await makeRequest<string>(`api/v1/cart/item`, "post", { skuId, quantity }),

  updateItemQuantity: async (id: CartItemId, quantity: number) =>
    await makeRequest<string>(`api/v1/cart/item`, "put", { id, quantity }),

  deleteFromCart: async (id: CartItemId) =>
    await makeRequest<string>(`api/v1/cart/item`, "delete", { id: id }),

  emptyCart: async () => await makeRequest<string>(`api/v1/cart`, "delete"),

  getCart: async () => await makeRequest<CartItem[]>(`api/v1/cart`),
}
export default cartApi
