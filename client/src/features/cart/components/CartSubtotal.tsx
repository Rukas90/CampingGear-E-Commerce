import { CostLabel, useCartItems } from "@features"
import { twMerge } from "tailwind-merge"

const CartSubtotal = ({
  className,
  ...props
}: Omit<React.ComponentProps<"p">, "children">) => {
  const items = useCartItems()

  const totalCartCost = items.reduce(
    (sum, item) => sum + item.unitPrice * item.quantity,
    0,
  )
  return (
    <CostLabel
      cost={totalCartCost}
      className={twMerge(
        "sm:text-2xl text-xl sm:font-medium font-semibold text-neutral-800",
        className,
      )}
      suffix="EUR"
      {...props}
    />
  )
}
export default CartSubtotal
