import type { CartItemId, CustomerId, SkuCode, SkuId } from "./brands"

export type Cart = {
  customerId: CustomerId
}

export type CartLineItem = {
  id: CartItemId
  quantity: number
}

export type CartItem = {
  id: CartItemId
  skuId: SkuId
  quantity: number
  unitPrice: number
  stock: number
  brandName: string
  brandSlug: string
  productName: string
  productSlug: string
  thumbnailUrl: string
  options: CartItemOption[]
}

export type CartItemOption = {
  groupName: string
  valueName: string
}

export type CartSummary = {
  count: number
}
