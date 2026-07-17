import { CartItemProvider, useCartItems } from "@features"
import CartItemEntry from "./CartItemEntry"
import { BrowseProductsButton, Line } from "@components"
import { twMerge } from "tailwind-merge"
import type { CartItem } from "@types"
import { Fragment } from "react/jsx-runtime"

interface CartEntriesListProps extends Omit<
  React.ComponentProps<"div">,
  "children" | "id"
> {
  renderItem?: (item: CartItem) => React.ReactNode
  showBrowseButton?: boolean
}

const CartEntriesList = ({
  className,
  renderItem,
  showBrowseButton,
  ...props
}: CartEntriesListProps) => {
  const items = useCartItems()

  const defaultRenderItem = (item: CartItem) => (
    <CartItemProvider item={item}>
      <CartItemEntry />
    </CartItemProvider>
  )

  const render = renderItem ?? defaultRenderItem

  return (
    <div
      id="cart-content"
      className={twMerge(
        "grow overflow-y-scroll overflow-x-hidden sm:px-10 px-5",
        className,
      )}
      {...props}
    >
      {items.length <= 0 && (
        <div className="flex flex-col justify-center pb-4">
          <p className="w-full text-neutral-400 mt-4 text-center mb-4 text-sm">
            No items in cart
          </p>
          {showBrowseButton && <BrowseProductsButton />}
        </div>
      )}
      {items?.map((item, index) => (
        <Fragment key={item.id}>
          {render(item)}
          {index < items.length - 1 && <Line />}
        </Fragment>
      ))}
    </div>
  )
}
export default CartEntriesList
