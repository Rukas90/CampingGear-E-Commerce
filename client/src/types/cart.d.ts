import type { SkuCode } from "./id"

export type Cart = {
  customerId: CustomerId
}

export type CartItem = {
  code: SkuCode
  quantity: number
}

export type CartSku = {
  code: SkuCode
  productName: string
  productSlug: string
  thumbnailUrl: string
  unitPrice: number
  stock: number
  options: CartSkuOption[]
}

export type CartEntry = CartItem & CartSku

export type CartSkuOption = {
  groupName: string
  valueName: string
}
