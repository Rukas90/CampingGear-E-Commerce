import type { CustomerId } from "./Id"

export type ProductCategory =
  | "handheld_gps"
  | "tent"
  | "backpack"
  | "sleeping_bag"

export type Cart = {
  customerId: CustomerId
}
export type CartItem = {
  id: CartItemId
}
