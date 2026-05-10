import { IconCart, IconSaved } from "@components"

interface ProductButtonsProps {
  stock: number
  isInSavedList?: boolean
  onAddToCart?: () => void
  onAddToWishlist?: () => void
}
const ProductButtons = ({
  stock,
  isInSavedList,
  onAddToCart,
  onAddToWishlist,
}: ProductButtonsProps) => {
  return (
    <div className="mt-4 flex gap-4 lg:flex-row flex-col">
      <button className="cursor-pointer" onClick={onAddToWishlist}>
        <IconSaved
          className="size-5"
          fill={isInSavedList ? "#000000" : "none"}
        />
      </button>
      <button
        onClick={onAddToCart}
        className="flex cursor-pointer font-medium gap-2 justify-center items-center w-full bg-black py-2.5 text-neutral-100 rounded-lg"
      >
        <IconCart className="size-5" />
        {stock > 0 ? "Add to Cart" : "Notify when available"}
      </button>
    </div>
  )
}
export default ProductButtons
