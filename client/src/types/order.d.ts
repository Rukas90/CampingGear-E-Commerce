export type OrderSummary = {
  token: string
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
