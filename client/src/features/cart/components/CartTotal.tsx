import {
  CartSubtotal,
  CheckoutButton,
  IconLock,
  Line,
  PaymentMethods,
} from "@features"

const CartTotal = () => {
  return (
    <div className="sm:sticky lg:w-90 w-full max-w-full shrink-0 top-24">
      <div className="flex flex-col items-center w-full shrink-0 px-8 py-6 rounded-lg border border-neutral-300 lg:bg-[hsl(60,3%,97%)]">
        <div className="flex flex-col gap-1.5 w-full">
          <div className="flex justify-between text-sm">
            <span className="font-medium">Subtotal:</span>
            <CartSubtotal className="text-sm sm:text-sm font-normal text-neutral-600" />
          </div>
          <div className="flex justify-between text-sm">
            <span className="font-medium">Tax:</span>
            <span className="text-sm text-neutral-600 my-auto">
              *Calculated at checkout
            </span>
          </div>
          <div className="flex justify-between text-sm">
            <span className="font-medium">Shipping:</span>
            <span className="text-sm text-neutral-600 my-auto">
              *Calculated at checkout
            </span>
          </div>
        </div>

        <Line className="my-2.5" />

        <div className="flex justify-between w-full">
          <span className="font-semibold">Total:</span>
          <CartSubtotal className="text-base sm:text-base font-semibold" />
        </div>

        <p className="text-sm text-neutral-500 mt-3">
          *Additional costs calculated at checkout
        </p>
        <a className="w-full" href="/checkout">
          <CheckoutButton className="w-full mt-5 flex items-center justify-center gap-2">
            <IconLock className="size-4.5 text-white" />
          </CheckoutButton>
        </a>
      </div>
      <p className="my-4 text-neutral-500 text-sm text-center">We accept</p>
      <PaymentMethods className="justify-center" cardClassName="h-6" />
    </div>
  )
}
export default CartTotal
