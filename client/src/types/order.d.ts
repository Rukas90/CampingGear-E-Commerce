import type { PostalAddress } from "./common"
import type { OrderToken } from "./id"

export type OrderSummary = {
  emailAddress: string
  token: OrderToken
  subtotal: number
  tax: number
  shippingCost: number
  shippingName: string
  total: number
  lineItems: OrderLineItem[]
}

export type OrderLineItem = {
  productName: string
  variantLine: string
  unitPrice: number
  quantity: number
  thumbnailUrl?: string
}

export type OrderPayment = {
  clientSecret: string
  order: OrderSummary
  billing: PostalAddress
}
