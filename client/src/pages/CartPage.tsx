import {
  CartCounter,
  CartEntriesList,
  CartTotal,
  PageWrapper,
} from "@components"
import { CartItemsProvider } from "@features"

const CartPage = () => {
  return (
    <CartItemsProvider>
      <title>Trailstore - Cart</title>
      <PageWrapper className="relative w-full flex items-start">
        <div className="flex lg:flex-row flex-col items-start gap-6 sm:py-18 py-8 w-full">
          <div className="w-full">
            <div className="flex sm:flex-row flex-col mb-4 justify-between items-center">
              <p className="flex gap-2.5 items-center">
                <span className="text-[1.5rem] font-semibold text-neutral-900">
                  Your shopping cart
                </span>
              </p>
              <div className="flex items-center gap-1.5 sm:my-0 my-4 text-neutral-500">
                <CartCounter className="p-0 bg-transparent text-neutral-500 m-0 text-sm font-normal size-auto" />{" "}
                <p className="text-sm">products</p>
              </div>
            </div>
            <CartEntriesList
              showBrowseButton
              className="sm:px-4 px-4 overflow-y-auto rounded-lg border border-neutral-300"
            />
          </div>
          <CartTotal />
        </div>
      </PageWrapper>
    </CartItemsProvider>
  )
}
export default CartPage
