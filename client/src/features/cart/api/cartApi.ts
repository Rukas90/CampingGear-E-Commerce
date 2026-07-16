import { makeRequest } from "@lib"
import type { CartItem, CartItemId, CartSummary, SkuId } from "@types"

const cartApi = {
  addToCart: async (skuId: SkuId, quantity: number) =>
    await makeRequest<string>(`api/v1/cart/item`, "post", { skuId, quantity }),

  updateItemQuantity: async (id: CartItemId, quantity: number) =>
    await makeRequest<string>(`api/v1/cart/item`, "put", {
      itemId: id,
      quantity,
    }),

  deleteFromCart: async (id: CartItemId) =>
    await makeRequest<string>(`api/v1/cart/item`, "delete", { itemId: id }),

  emptyCart: async () => await makeRequest<string>(`api/v1/cart`, "delete"),

  getCart: async () => await makeRequest<CartItem[]>(`api/v1/cart`),

  getSummary: async () => await makeRequest<CartSummary>(`api/v1/cart/summary`),
}
export default cartApi
