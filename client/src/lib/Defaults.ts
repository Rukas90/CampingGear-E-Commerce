import type { PostalAddress } from "@types"

export const DEFAULT_ADDRESS: PostalAddress = {
  countryCode: "LT",
  recipientFirstName: "",
  recipientLastName: "",
  company: undefined,
  addressLine: "",
  apartmentSuite: undefined,
  city: "",
  region: "",
  postalCode: "",
  phoneNumber: "",
}
