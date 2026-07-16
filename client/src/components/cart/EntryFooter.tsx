import { useCartItem, useWishlist } from "@features"
import { formatPrice } from "@utils"
import { useNavigate } from "react-router-dom"

const EntryFooter = () => {
  const { item, totalPrice, remove } = useCartItem()
  const { addItem } = useWishlist()
  const navigate = useNavigate()

  const handleSave = async () => {
    if (await addItem(item.skuId)) {
      remove()
      navigate("/wishlist")
    }
  }

  return (
    <div className="flex justify-between w-full mt-1">
      <button
        onClick={handleSave}
        className="text-sm underline hover:no-underline text-neutral-600 cursor-pointer"
      >
        Save for later
      </button>
      <p className="text-sm font-medium">Total: {formatPrice(totalPrice)}</p>
    </div>
  )
}
export default EntryFooter
