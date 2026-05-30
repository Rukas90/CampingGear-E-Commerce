import { AddToCartQuantity, IconButton, IconTrash } from "@components"
import EntryFooter from "./EntryFooter"
import EntryHeader from "./EntryHeader"
import { useCartItem } from "@features"

const EntryContent = () => {
  const { item, updateQuantity, remove } = useCartItem()

  const handleQunatityChange = (newQuantity: number) => {
    updateQuantity(Math.min(Math.max(newQuantity, 1), item.stock))
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
        <div className="ml-auto">
          <IconButton
            onClick={remove}
            icon={<IconTrash className="size-4.5 text-neutral-600" />}
          />
        </div>
      </div>
      <EntryFooter />
    </div>
  )
}
export default EntryContent
