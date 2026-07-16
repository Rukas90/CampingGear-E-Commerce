export const Availability = {
  OutOfStock: 1 << 0,
  InStock: 1 << 1,
  All: (1 << 0) | (1 << 1),
} as const

export enum PreviewType {
  None = "None",
  Color = "Color",
  Image = "Image",
}

export const ReviewSortBy = {
  MostRecent: "MostRecent",
  HighestRating: "HighestRating",
  LowestRating: "LowestRating",
  MostHelpful: "MostHelpful",
} as const

export const CheckoutStatus = {
  Draft: "Draft",
  Complete: "Complete",
} as const

export const PostalCodeRequirement = {
  None: "None",
  Optional: "Optional",
  Required: "Required",
} as const

export const OrderStatus = {
  Pending: "Pending",
  OnHold: "OnHold",
  Processing: "Processing",
  Failed: "Failed",
  Canceled: "Canceled",
  Completed: "Completed",
} as const

export const PaymentStatus = {
  Pending: "Pending",
  Succeeded: "Succeeded",
  Failed: "Failed",
  Canceled: "Canceled",
} as const
