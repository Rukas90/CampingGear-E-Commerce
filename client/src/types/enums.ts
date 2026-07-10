export const Availability = {
  OutOfStock: 1 << 0,
  InStock: 1 << 1,
  All: (1 << 0) | (1 << 1),
} as const

export type Availability = (typeof Availability)[keyof typeof Availability]

export enum PreviewType {
  None = -1,
  Color = 0,
  Image = 1,
}

export const ReviewSortBy = {
  MostRecent: 0,
  HighestRating: 1,
  LowestRating: 2,
  MostHelpful: 3,
} as const

export type ReviewSortBy = (typeof ReviewSortBy)[keyof typeof ReviewSortBy]

export const CheckoutStatus = {
  Form: 0,
  Complete: 1,
} as const

export type CheckoutStatus =
  (typeof CheckoutStatus)[keyof typeof CheckoutStatus]

export const PostalCodeRequirement = {
  None: 0,
  Optional: 1,
  Required: 2,
} as const

export type PostalCodeRequirement =
  (typeof PostalCodeRequirement)[keyof typeof PostalCodeRequirement]

export const PaymentStatus = {
  Pending: 0,
  Succeeded: 1,
  Failed: 2,
  Canceled: 3,
} as const
