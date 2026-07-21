import clsx from "clsx"
import CartQuantityButton from "./CartQuantityButton"

interface AddToCartQuantityProps {
  quantity: number
  onQuantityChanged?: (quantity: number) => void
  disabled?: boolean
  style?: "regular" | "small"
}
const AddToCartQuantity = ({
  quantity,
  onQuantityChanged,
  disabled,
  style,
}: AddToCartQuantityProps) => {
  return (
    <div className="flex">
      <CartQuantityButton
        onClick={() => onQuantityChanged?.(quantity - 1)}
        disabled={disabled}
        className={clsx(style === "small" && "text-sm w-8")}
      >
        −
      </CartQuantityButton>
      <input
        value={quantity}
        onChange={(e) => onQuantityChanged?.(parseInt(e.target.value) || 1)}
        type="number"
        className={clsx(
          "border-y-2 border-neutral-200 text-center py-0.5 z-1 [appearance:textfield] [&::-webkit-outer-spin-button]:appearance-none [&::-webkit-inner-spin-button]:appearance-none",
          disabled && "text-neutral-400",
          style === "small" ? "text-sm w-10" : "w-16",
        )}
        disabled={disabled}
      />
      <CartQuantityButton
        onClick={() => onQuantityChanged?.(quantity + 1)}
        disabled={disabled}
        className={clsx(style === "small" && "text-sm w-8")}
      >
        +
      </CartQuantityButton>
    </div>
  )
}
export default AddToCartQuantity
