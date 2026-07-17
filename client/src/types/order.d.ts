import type { PostalAddress } from "./common"
import type { OrderStatus } from "./enums"
import type { OrderId, OrderToken } from "./brands"

export type OrderDetails = {
  emailAddress: string
  token: OrderToken
  financials: Financials
  shippingName: string
  status: OrderStatusType
  createdAt: string
  lineItems: OrderLineItem[]
  billing: PostalAddress
}

export type OrderSummary = {
  id: OrderId
  token: OrderToken
  createdAt: string
  status: OrderStatusType
  total: number
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

export type OrderStatusType = (typeof OrderStatus)[keyof typeof OrderStatus]
