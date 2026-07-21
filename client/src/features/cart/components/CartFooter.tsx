import { CartSubtotal, ContrastButton, Line, PopButton } from "@features"

const CartFooter = () => {
  return (
    <div id="cart-footer" className="relative sm:px-10 px-5">
      <Line className="absolute top-0 left-0 bg-neutral-200" />
      <div className="pb-6 pt-8 px-2">
        <div className="flex justify-between">
          <p className="sm:text-2xl text-xl font-medium text-neutral-800">
            Subtotal
          </p>
          <CartSubtotal />
        </div>
        <p className="sm:mt-2 mt-3 text-sm text-neutral-600">
          Free standard shipping on orders 99 EUR+
        </p>
      </div>

      <div className="flex gap-4">
        <a className="w-1/2" href="/cart">
          <PopButton className="sm:py-4 py-2.5 sm:text-base text-sm w-full bg-[#e9e9e8]">
            View Cart
          </PopButton>
        </a>
        <a className="w-1/2" href="/checkout">
          <ContrastButton className="sm:py-4 py-2.5 sm:text-base text-sm w-full">
            Checkout
          </ContrastButton>
        </a>
      </div>
    </div>
  )
}
export default CartFooter
