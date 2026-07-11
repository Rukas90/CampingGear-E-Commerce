import type { CartItem } from "@types"
import { createContext, useContext } from "react"
import cartApi from "../api/cartApi"
import { useCartContext } from "./CartContext"
import { useSessionSummary } from "@features"

interface CartItemData {
  item: CartItem
  totalPrice: number
  updateQuantity: (quantity: number) => void
  remove: () => void
}

const CartItemContext = createContext<CartItemData | undefined>(undefined)

export const CartItemProvider = ({
  item,
  children,
}: React.PropsWithChildren<{ item: CartItem }>) => {
  const { invalidateCart } = useCartContext()
  const { invalidate: invalidateSession } = useSessionSummary()

  const id = item.id

  const updateQuantity = async (quantity: number) => {
    await cartApi.updateItemQuantity(id, quantity)
    await invalidateCart()
    await invalidateSession()
  }

  const remove = async () => {
    await cartApi.deleteFromCart(id)
    await invalidateCart()
    await invalidateSession()
  }

  return (
    <CartItemContext.Provider
      value={{
        item,
        totalPrice: item.unitPrice * item.quantity,
        updateQuantity,
        remove,
      }}
    >
      {children}
    </CartItemContext.Provider>
  )
}

export const useCartItem = () => {
  const context = useContext(CartItemContext)

  if (!context) {
    throw new Error("useCartItem must be used within CartItemProvider")
  }
  return context
}
