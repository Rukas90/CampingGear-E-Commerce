import type { CartItem } from "@types"
import { createContext, useContext } from "react"
import useCart from "../hooks/useCart"

interface CartItemsData {
  items: CartItem[]
}

const CartItemsContext = createContext<CartItemsData | undefined>(undefined)

export const CartItemsProvider = ({ children }: React.PropsWithChildren) => {
  const { items } = useCart()

  return (
    <CartItemsContext.Provider value={{ items: items ?? [] }}>
      {children}
    </CartItemsContext.Provider>
  )
}

export const useCartItems = () => {
  const context = useContext(CartItemsContext)

  if (!context) {
    throw new Error("useCartItems must be used within CartItemsProvider")
  }
  return context.items
}
