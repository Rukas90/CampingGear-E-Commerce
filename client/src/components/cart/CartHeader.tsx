import { IconButton, IconX, Line } from "@components"
import { useCart } from "@features"
import CartCounter from "./CartCounter"

const CartHeader = () => {
  const { closeCartPanel } = useCart()

  return (
    <div id="cart-header" className="px-10">
      <div className="flex justify-between items-center">
        <div className="flex items-center gap-3">
          <p className="text-[1.65rem] font-medium tracking-normal">
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
