import { CartSubtotal, Line } from "@components"

const CartFooter = () => {
  return (
    <div id="cart-footer" className="relative px-10">
      <Line className="absolute top-0 left-0 bg-neutral-200" />
      <div className="pb-6 pt-8 px-2">
        <div className="flex justify-between">
          <p className="text-2xl font-medium text-neutral-800">Subtotal</p>
          <CartSubtotal />
        </div>
        <p className="mt-2 text-sm text-neutral-600">
          Free standard shipping on orders 99 EUR+
        </p>
      </div>

      <div className="flex gap-4">
        <a className="w-1/2" href="/cart">
          <button className="bg-[#e9e9e8] hover:bg-black text-black hover:text-white font-medium w-full py-4 rounded-lg">
            View Cart
          </button>
        </a>
        <button className="bg-black text-white font-medium w-1/2 py-4 rounded-lg">
          Checkout
        </button>
      </div>
    </div>
  )
}
export default CartFooter
