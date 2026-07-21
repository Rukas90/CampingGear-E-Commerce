import { useCartItems } from "@features"
import { twMerge } from "tailwind-merge"

const CartCounter = ({
  className,
  ...props
}: Omit<React.ComponentProps<"p">, "children">) => {
  const items = useCartItems()

  return (
    <p
      className={twMerge(
        "flex bg-black rounded-full text-white size-5 font-semibold items-center justify-center text-sm mb-4",
        className,
      )}
      {...props}
    >
      {items.length}
    </p>
  )
}
export default CartCounter
