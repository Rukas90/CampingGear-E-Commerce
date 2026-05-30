import {
  CartCounter,
  CartEntriesList,
  CartTotal,
  Line,
  PageWrapper,
} from "@components"
import { CartItemsProvider } from "@features"

const CartPage = () => {
  return (
    <CartItemsProvider>
      <PageWrapper className="relative w-full flex items-start">
        <div className="flex items-start gap-24 py-24 w-full">
          <div className="w-full">
            <div className="flex justify-between items-center">
              <p className="flex gap-2.5 items-center">
                <span className="text-[1.5rem] font-semibold text-neutral-900">
                  Your shopping cart
                </span>
              </p>
              <div className="flex items-center gap-1.5 text-neutral-500">
                <CartCounter className="p-0 bg-transparent text-neutral-500 m-0 text-sm font-normal size-auto" />{" "}
                <p className="text-sm">products</p>
              </div>
            </div>
            <Line className="my-2.5" />
            <CartEntriesList className="px-0 overflow-y-auto" />
          </div>
          <CartTotal />
        </div>
      </PageWrapper>
    </CartItemsProvider>
  )
}
export default CartPage
