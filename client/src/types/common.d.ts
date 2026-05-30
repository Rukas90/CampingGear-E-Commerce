import type { PostalCodeRequirement } from "./enums"

export type Country = {
  code: string
  name: string

  postalCodeLabel?: string
  regionLabel?: string

  hasRegion: boolean
  postalCode: PostalCodeRequirement

  phoneCode: string
}

export type PostalAddress = {
  countryCode?: string
  recipientFirstName?: string
  recipientLastName?: string
  company?: string
  addressLine?: string
  apartmentSuite?: string
  city?: string
  region?: string
  postalCode?: string
  phoneNumber?: string
}
