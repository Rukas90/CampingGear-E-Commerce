import { IconButton, IconX, Line, useCartContext } from "@features"
import CartCounter from "./CartCounter"

const CartHeader = () => {
  const { closeCartPanel } = useCartContext()

  return (
    <div id="cart-header" className="sm:px-10 px-5">
      <div className="flex justify-between items-center">
        <div className="flex items-center gap-3">
          <p className="sm:text-[1.65rem] text-[1.3rem] sm:font-medium font-semibold tracking-normal">
            Your Cart
          </p>
          <CartCounter />
        </div>
        <IconButton
          onClick={closeCartPanel}
          icon={<IconX className="size-3" strokeWidth="4" />}
        />
      </div>
      <Line className="my-4" />
    </div>
  )
}
export default CartHeader
