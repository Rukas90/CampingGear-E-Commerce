import { IconCart, useCartContext, useWishlist } from "@features"
import type { ProductSku } from "@types"
import WishlistToggle from "./WishlistToggle"

interface ProductButtonsProps {
  stock: number
  unitPrice: number
  quantity: number
  sku?: ProductSku
}
const ProductButtons = ({
  stock,
  unitPrice,
  quantity,
  sku,
}: ProductButtonsProps) => {
  const { addItem } = useCartContext()
  const { toggleItem, isInWishlist } = useWishlist()

  const handleAddToCart = () => {
    if (!sku) {
      return
    }
    addItem(sku.id, quantity)
  }

  const handleWishlistToggle = () => {
    if (!sku) {
      return
    }
    toggleItem(sku.id)
  }

  return (
    <div className="mt-4 flex gap-4 lg:flex-row flex-col">
      <WishlistToggle
        isSaved={!!sku && isInWishlist(sku.id)}
        toggle={handleWishlistToggle}
      />
      <button
        onClick={handleAddToCart}
        className="flex cursor-pointer font-medium gap-2 justify-center items-center w-full bg-black py-2.5 text-neutral-100 rounded-lg"
      >
        <IconCart className="size-5" />
        {stock > 0 ? "Add to Cart" : "Notify when available"}
        {stock > 0 && quantity > 1 && (
          <span className="font-normal"> - ${unitPrice * quantity}€</span>
        )}
      </button>
    </div>
  )
}
export default ProductButtons
