import clsx from "clsx"
import ProductCartButton from "./ProductCartButton"

interface ProductAddToCartQuantityProps {
  quantity: number
  onQuantityChanged?: (quantity: number) => void
  disabled?: boolean
}
const ProductAddToCartQuantity = ({
  quantity,
  onQuantityChanged,
  disabled,
}: ProductAddToCartQuantityProps) => {
  return (
    <div className="flex">
      <ProductCartButton
        onClick={() => onQuantityChanged?.(quantity - 1)}
        disabled={disabled}
      >
        −
      </ProductCartButton>
      <input
        value={quantity}
        onChange={(e) => onQuantityChanged?.(parseInt(e.target.value) || 1)}
        type="number"
        className={clsx(
          "border-y-2 border-neutral-200 text-center py-0.5 w-16 z-1 [appearance:textfield] [&::-webkit-outer-spin-button]:appearance-none [&::-webkit-inner-spin-button]:appearance-none",
          disabled && "text-neutral-400",
        )}
        disabled={disabled}
      />
      <ProductCartButton
        onClick={() => onQuantityChanged?.(quantity + 1)}
        disabled={disabled}
      >
        +
      </ProductCartButton>
    </div>
  )
}
export default ProductAddToCartQuantity
