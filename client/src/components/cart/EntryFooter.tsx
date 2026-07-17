import { useCartItem } from "@features"
import { formatPrice } from "@utils"

interface EntryFooterProps {
  addToWishlist: () => void
}
const EntryFooter = ({ addToWishlist }: EntryFooterProps) => {
  const { totalPrice } = useCartItem()

  return (
    <div className="flex justify-between w-full mt-1">
      <button
        onClick={addToWishlist}
        className="sm:block hidden text-sm underline hover:no-underline text-neutral-600 cursor-pointer"
      >
        Save for later
      </button>
      <p className="text-sm font-medium sm:mt-0 mt-4">
        Total: {formatPrice(totalPrice)}
      </p>
    </div>
  )
}
export default EntryFooter
