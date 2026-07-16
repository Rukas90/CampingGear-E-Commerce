import { makeRequest } from "@lib"
import type { SkuId, WishlistItem } from "@types"

const wishlistApi = {
  add: (skuId: SkuId) =>
    makeRequest("/api/v1/wishlist", "post", { skuId: skuId }),
  remove: (skuId: SkuId) =>
    makeRequest("/api/v1/wishlist", "delete", { skuId: skuId }),
  getAll: () => makeRequest<WishlistItem[]>("/api/v1/wishlist"),
}
export default wishlistApi
