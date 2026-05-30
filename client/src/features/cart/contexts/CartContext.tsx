import type { CartLineItem } from "@types"
import { createContext, useContext, useState } from "react"
import cartApi from "../api/cartApi"
import { useQueryClient } from "@tanstack/react-query"
import { useSessionSummary } from "@features"

interface CartData {
  isCartPanelOpen: boolean
  openCartPanel: () => void
  closeCartPanel: () => void
  addItem: (item: CartLineItem) => void
  invalidateCart: () => Promise<void>
}

const CartContext = createContext<CartData | undefined>(undefined)

export const CartProvider = ({ children }: React.PropsWithChildren) => {
  const [isCartPanelOpen, setIsCartOpen] = useState(false)
  const queryClient = useQueryClient()
  const { invalidate: invalidateSession } = useSessionSummary()

  const openCartPanel = () => setIsCartOpen(true)
  const closeCartPanel = () => setIsCartOpen(false)

  const addItem = async (item: CartLineItem) => {
    await cartApi.addToCart(item)
    await invalidateCart()
    await invalidateSession()

    openCartPanel()
  }

  const invalidateCart = async () =>
    await queryClient.invalidateQueries({ queryKey: ["cart"] })

  return (
    <CartContext.Provider
      value={{
        isCartPanelOpen,
        openCartPanel,
        closeCartPanel,
        addItem,
        invalidateCart,
      }}
    >
      {children}
    </CartContext.Provider>
  )
}

export const useCart = () => {
  const context = useContext(CartContext)

  if (!context) {
    throw new Error("Can only use useCart within the CartProvider!")
  }
  return context
}
