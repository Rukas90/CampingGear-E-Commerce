import {
  AddToCartQuantity,
  IconButton,
  IconTrash,
  TextButton,
} from "@components"
import EntryFooter from "./EntryFooter"
import EntryHeader from "./EntryHeader"
import { useCartItem, useWishlist } from "@features"
import { useNavigate } from "react-router-dom"

const EntryContent = () => {
  const { item, updateQuantity, remove } = useCartItem()
  const { addItem } = useWishlist()
  const navigate = useNavigate()

  const handleQunatityChange = (newQuantity: number) => {
    updateQuantity(Math.min(Math.max(newQuantity, 1), item.stock))
  }
  const handleSave = async () => {
    if (await addItem(item.skuId)) {
      remove()
      navigate("/wishlist")
    }
  }

  return (
    <div className="flex flex-col justify-between pl-6 w-full">
      <div className="flex">
        <div>
          <EntryHeader />
          <div className="mt-1">
            <AddToCartQuantity
              quantity={item.quantity}
              onQuantityChanged={handleQunatityChange}
              style="small"
            />
          </div>
        </div>
        <div className="ml-auto sm:block hidden">
          <IconButton
            onClick={remove}
            icon={<IconTrash className="size-4.5 text-neutral-600" />}
          />
        </div>
      </div>
      <EntryFooter addToWishlist={handleSave} />
      <div className="sm:hidden flex flex-col gap-1 items-start mt-4 mb-2">
        <TextButton onClick={handleSave}>Save for later</TextButton>
        <TextButton onClick={remove}>Remove item</TextButton>
      </div>
    </div>
  )
}
export default EntryContent
