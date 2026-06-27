import { CartItemProvider, useCartItems } from "@features"
import CartItemEntry from "./CartItemEntry"
import { Line } from "@components"
import { twMerge } from "tailwind-merge"
import type { CartItem } from "@types"
import { Fragment } from "react/jsx-runtime"

interface CartEntriesListProps extends Omit<
  React.ComponentProps<"div">,
  "children" | "id"
> {
  renderItem?: (item: CartItem) => React.ReactNode
}

const CartEntriesList = ({
  className,
  renderItem,
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
        "grow overflow-y-scroll overflow-x-hidden px-10",
        className,
      )}
      {...props}
    >
      {items.length <= 0 && (
        <p className="w-full text-neutral-400 mt-4 text-center">
          No items in cart
        </p>
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
