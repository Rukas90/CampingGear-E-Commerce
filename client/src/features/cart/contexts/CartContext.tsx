import { useAccount } from "@features"
import type { CartItem, SkuCode } from "@types"
import { createContext, useContext } from "react"
import useCartStorage from "../hooks/useCartStorage"

interface CartData {
  items: CartItem[]
  count: number
  addItem: (item: CartItem) => void
  updateQuantity: (code: SkuCode, newQuantity: number) => void
  removeItem: (code: SkuCode) => void
  getCount: () => number
}

const CartContext = createContext<CartData | undefined>(undefined)

export const CartProvider = ({ children }: React.PropsWithChildren) => {
  const { isLoggedIn } = useAccount()
  const {
    addItemToStorage,
    removeItemFromStorage,
    updateStorageItemQuantity,
    items,
  } = useCartStorage()

  const addItem = (item: CartItem) => {
    if (!isLoggedIn) {
      return addItemToStorage(item)
    }
  }

  const updateQuantity = (code: SkuCode, newQuantity: number) => {
    if (!isLoggedIn) {
      return updateStorageItemQuantity(code, newQuantity)
    }
  }

  const removeItem = (code: SkuCode) => {
    if (!isLoggedIn) {
      return removeItemFromStorage(code)
    }
  }

  const getCount = () => {
    if (!isLoggedIn) {
      return items.length
    }
    return 0
  }

  return (
    <CartContext.Provider
      value={{
        items: !isLoggedIn ? items : [],
        count: getCount(),
        addItem,
        updateQuantity,
        removeItem,
        getCount,
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
