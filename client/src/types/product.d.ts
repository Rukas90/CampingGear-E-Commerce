import type { CustomerId } from "./Id"

export type ProductCategory =
  | "handheld-gps"
  | "tents"
  | "backpacks"
  | "sleeping-bags"

export type Cart = {
  customerId: CustomerId
}
export type CartItem = {
  id: CartItemId
}

export type Category = {
  id: CategoryId
  name: string
  description?: string
  slug: string
  imageUrl?: string
}
