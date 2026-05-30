import {
  CartSubtotal,
  CheckoutButton,
  IconLock,
  Line,
  PaymentMethods,
} from "@components"

const CartTotal = () => {
  return (
    <div className="sticky min-w-90 top-24">
      <div className="flex flex-col items-center w-full shrink-0 px-8 py-6 rounded-lg border border-neutral-300 bg-stone-100">
        <p className="uppercase mb-4 text-sm font-medium text-neutral-400">
          Order summary
        </p>
        <div className="flex flex-col gap-1 w-full">
          <div className="flex justify-between text-sm">
            <span>Subtotal:</span>
            <CartSubtotal className="text-sm font-normal text-neutral-500" />
          </div>
          <div className="flex justify-between text-sm">
            <span>Shipping:</span>
            <span className="text-sm text-neutral-500 my-auto">
              *Calculated at checkout
            </span>
          </div>
        </div>

        <Line className="my-2.5" />

        <div className="flex justify-between w-full">
          <span className="font-semibold">Total:</span>
          <CartSubtotal className="text-base font-semibold" />
        </div>

        <p className="text-sm text-neutral-500 mt-3">
          *Additional costs calculated at checkout
        </p>
        <a className="w-full" href="/checkout">
          <CheckoutButton className="w-full mt-5 flex items-center justify-center gap-2">
            <IconLock className="size-4.5 text-white" />
          </CheckoutButton>
        </a>
        <p className="my-4 text-neutral-500 text-sm">We accept</p>
        <PaymentMethods cardClassName="h-6" />
      </div>
    </div>
  )
}
export default CartTotal
