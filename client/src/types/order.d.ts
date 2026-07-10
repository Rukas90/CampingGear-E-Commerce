import type { PostalAddress } from "./common"
import type { OrderToken } from "./id"

export type OrderSummary = {
  emailAddress: string
  token: OrderToken
  financials: Financials
  shippingName: string
  lineItems: OrderLineItem[]
  billing: PostalAddress
}

export type OrderLineItem = {
  brandName: string
  productName: string
  variantLine: string
  unitPrice: number
  quantity: number
  thumbnailUrl?: string
}

export type Financials = {
  subtotal: number
  tax: number
  shippingCost: number
  total?: number
}

export type FreeShippingInfo = {
  eligibleForFreeShipping: boolean
  addCostForFreeShipping: number
}
