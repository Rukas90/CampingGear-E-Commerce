import type { PostalAddress } from "./common"
import type { CheckoutStatus } from "./enums"

export type CheckoutForm = {
  contact: CheckoutContact
  shippingAddress?: PostalAddress
  billing: CheckoutBilling
}

export type CheckoutContact = {
  emailAddress?: string
}

export type CheckoutBilling = {
  address?: PostalAddress
  asShippingAddress: boolean
}

export type Checkout = {
  status: CheckoutStatus
}
