import { useCartItem } from "@features"
import { formatPrice } from "@utils"

const EntryFooter = () => {
  const { totalPrice } = useCartItem()

  return (
    <div className="flex justify-between w-full mt-1">
      <button
        onClick={() => console.log("TODO")}
        className="text-sm underline hover:no-underline text-neutral-600 cursor-pointer"
      >
        Save for later
      </button>
      <p className="text-sm font-medium">Total: {formatPrice(totalPrice)}</p>
    </div>
  )
}
export default EntryFooter
