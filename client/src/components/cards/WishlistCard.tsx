import { CancelButton, ContrastButton, PopButton, Toggle } from "@components"
import { useCartContext } from "@features"
import type { WishlistItem } from "@types"
import { formatPrice } from "@utils"
import { useState } from "react"
import { Link } from "react-router-dom"

interface WishlistCardProps {
  item: WishlistItem
  onRemove: () => void
  disabled?: boolean
}

const WishlistCard = ({ item, onRemove, disabled }: WishlistCardProps) => {
  const productLink = `/product/${item.productSlug}?variant=${item.skuCode}`
  const { addItem } = useCartContext()
  const [selected, setSelected] = useState(false)

  const handleToggleSeletion = () => setSelected((value) => !value)

  const handleTransferToCart = () => {
    addItem(item.skuId, 1)
    onRemove()
  }

  return (
    <div className="flex flex-col p-4 border border-neutral-400 rounded-md">
      <button
        onClick={handleToggleSeletion}
        className="relative h-75 bg-[#E3E3E3] p-4 cursor-pointer"
      >
        <img
          className="w-full h-full object-contain mix-blend-darken"
          src={item.thumbnailUrl}
        />
        <Toggle
          checked={selected}
          className={(_) => "absolute top-4 right-4"}
        />
      </button>
      <div className="flex gap-2 flex-col mt-4 flex-1">
        <p className="text-accent-dark text-xs">{item.brandName}</p>
        <p className="text-black text-sm font-semibold">{item.productName}</p>
        <p className="text-black text-base">{formatPrice(item.unitPrice)}</p>
        <p className="text-neutral-600 my-2.5 text-sm">{item.variantLine}</p>
        <div className="flex flex-col gap-2 mt-auto">
          <Link to={productLink}>
            <PopButton
              className="py-2.5 text-sm font-semibold bg-stone-50 uppercase w-full"
              disabled={disabled}
            >
              View Product
            </PopButton>
          </Link>
          <ContrastButton
            className="py-2.5 font-bold text-sm uppercase"
            disabled={disabled}
            onClick={handleTransferToCart}
          >
            Add to Cart
          </ContrastButton>
          <CancelButton
            onClick={onRemove}
            className="py-2.5 text-sm font-semibold bg-stone-50 uppercase"
            disabled={disabled}
          >
            Remove
          </CancelButton>
        </div>
      </div>
    </div>
  )
}
export default WishlistCard
