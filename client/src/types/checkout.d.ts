import type { PostalAddress } from "./common"
import type { CheckoutStatus } from "./enums"
import type { OrderToken } from "./id"

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
  subtotal: number
  total?: number
  tax?: number
  shippingCost?: number
  addCostForFreeShipping?: number
  eligibleForFreeShipping: boolean
}

export type CheckoutConfirmation = {
  orderToken: OrderToken
}
