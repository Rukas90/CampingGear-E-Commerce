import { CartItemsProvider, useCartContext } from "@features"
import CartFooter from "./CartFooter"
import CartEntriesList from "./CartEntriesList"
import CartHeader from "./CartHeader"
import { useLocation } from "react-router-dom"
import { useRef } from "react"
import { CustomPointer, IconX } from "@components"

const CART_PATH = "/cart"

const CartSidePanel = () => {
  const { isCartPanelOpen, closeCartPanel } = useCartContext()
  const containerRef = useRef<HTMLDivElement | null>(null)

  const location = useLocation()
  const isOnCartPage = location.pathname === CART_PATH

  if (!isCartPanelOpen || isOnCartPage) {
    return null
  }

  return (
    <CartItemsProvider>
      <div
        ref={containerRef}
        className="absolute top-0 left-0 bg-[#00000085] w-full h-full z-128"
        onClick={closeCartPanel}
      >
        <CustomPointer
          className="size-8 rounded-full bg-white shadow-md z-129 p-2.5"
          innerRender={(_) => <IconX strokeWidth={3} />}
          containerRef={containerRef}
        />
        <div
          className="fixed h-full w-lg max-w-full right-0 top-0 p-4 z-130"
          onClick={(e) => e.stopPropagation()}
        >
          <div className="flex flex-col justify-between bg-stone-100 w-full h-full rounded-lg py-8">
            <CartHeader />
            <CartEntriesList />
            <CartFooter />
          </div>
        </div>
      </div>
    </CartItemsProvider>
  )
}
export default CartSidePanel
