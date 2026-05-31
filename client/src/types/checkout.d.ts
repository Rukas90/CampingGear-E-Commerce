import type { PostalAddress } from "./common"
import type { CheckoutStatus } from "./enums"

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
  freeShippingThreshold: number
}

export type CheckoutBilling = {
  address?: PostalAddress
  asShippingAddress: boolean
}

export type CheckoutStats = {
  status: CheckoutStatus
  subtotal: number
  total: number
  tax?: number
  shippingCost?: number
}
