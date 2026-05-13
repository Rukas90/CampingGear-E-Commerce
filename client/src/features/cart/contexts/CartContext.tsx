import { createContext } from "react"

interface CartData {}

const CartContext = createContext<CartData | undefined>(undefined)

const CartProvider = ({ children }: React.PropsWithChildren) => {
  const addItem = () => {}
  const removeItem = () => {}

  return <CartContext.Provider value={{}}>{children}</CartContext.Provider>
}

const useCart = () => {}
export default useCart
