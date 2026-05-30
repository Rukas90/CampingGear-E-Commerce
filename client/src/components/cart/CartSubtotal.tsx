import { useCartItems } from "@features"
import { formatPrice } from "@utils"
import { twMerge } from "tailwind-merge"

const CartSubtotal = ({
  className,
  ...props
}: Omit<React.ComponentProps<"span">, "children">) => {
  const items = useCartItems()

  const totalCartCost = items.reduce(
    (sum, item) => sum + item.unitPrice * item.quantity,
    0,
  )
  return (
    <span
      className={twMerge("text-2xl font-medium text-neutral-800", className)}
      {...props}
    >
      {formatPrice(totalCartCost)} EUR
    </span>
  )
}
export default CartSubtotal
