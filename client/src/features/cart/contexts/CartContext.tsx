import type { SkuId } from "@types"
import { createContext, useContext, useState } from "react"
import cartApi from "../api/cartApi"
import { useQueryClient } from "@tanstack/react-query"

interface CartData {
  isCartPanelOpen: boolean
  openCartPanel: () => void
  closeCartPanel: () => void
  addItem: (skuId: SkuId, quantity: number) => void
  invalidateCart: () => Promise<void>
}

const CartContext = createContext<CartData | undefined>(undefined)

export const CartProvider = ({ children }: React.PropsWithChildren) => {
  const [isCartPanelOpen, setIsCartOpen] = useState(false)
  const queryClient = useQueryClient()

  const openCartPanel = () => setIsCartOpen(true)
  const closeCartPanel = () => setIsCartOpen(false)

  const addItem = async (skuId: SkuId, quantity: number) => {
    await cartApi.addToCart(skuId, quantity)
    await invalidateCart()

    openCartPanel()
  }

  const invalidateCart = async () => {
    await queryClient.invalidateQueries({
      queryKey: ["cart", "session-summary"],
    })
  }

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

export const useCartContext = () => {
  const context = useContext(CartContext)

  if (!context) {
    throw new Error("Can only use useCart within the CartProvider!")
  }
  return context
}
