import type { SkuCode, SkuId } from "./id"

export type CustomerAccount = {
  id: string
  email: string
}

export type WishlistItem = {
  skuId: SkuId
  brandName: string
  productName: string
  productSlug: string
  skuCode: SkuCode
  unitPrice: number
  variantLine: string
  thumbnailUrl?: string
}
