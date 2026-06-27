import type { SkuCode } from "./id"

export type Cart = {
  customerId: CustomerId
}

export type CartLineItem = {
  id: CartItemId
  quantity: number
}

export type CartItem = {
  id: CartItemId
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
