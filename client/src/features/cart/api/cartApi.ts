import { makeRequest } from "@lib"
import type { CartItem, CartLineItem, SkuCode } from "@types"

const cartApi = {
  addToCart: async (item: CartLineItem) =>
    await makeRequest<string>(`api/v1/cart/item`, "post", item),

  updateItemQuantity: async (item: CartLineItem) =>
    await makeRequest<string>(`api/v1/cart/item`, "put", item),

  deleteFromCart: async (code: SkuCode) =>
    await makeRequest<string>(`api/v1/cart/item`, "delete", { code: code }),

  emptyCart: async () => await makeRequest<string>(`api/v1/cart`, "delete"),

  getCart: async () => await makeRequest<CartItem[]>(`api/v1/cart`),
}
export default cartApi
