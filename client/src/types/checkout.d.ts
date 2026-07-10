import type { PostalAddress } from "./common"
import type { CheckoutStatus } from "./enums"
import type { OrderId, OrderToken } from "./id"
import type { Financials, FreeShippingInfo } from "./order"

export type CheckoutForm = {
  contact: CheckoutContact
  shipping: CheckoutShipping
  billing: CheckoutBilling
}

export type CheckoutContact = {
  emailAddress?: string
}

export type CheckoutShipping = {
  address?: PostalAddress
  selectedMethodId: ShippingMethodId
}

export type ShippingMethod = {
  id: ShippingMethodId
  name: string
  description: string
  flatFee: number
}

export type CheckoutBilling = {
  address?: PostalAddress
  asShippingAddress: boolean
}

export type CheckoutStats = {
  status: CheckoutStatus
  financials: Financials
  freeShippingInfo: FreeShippingInfo
}

export type CheckoutConfirmation = {
  orderId: OrderId
}

export type CheckoutStatusType =
  (typeof CheckoutStatus)[keyof typeof CheckoutStatus]
