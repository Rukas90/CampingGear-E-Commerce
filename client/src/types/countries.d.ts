import type { PostalCodeRequirement } from "./enums"

export type PostalCodeRequirementType =
  (typeof PostalCodeRequirement)[keyof typeof PostalCodeRequirement]
