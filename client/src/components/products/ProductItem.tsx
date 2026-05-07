import type { ProductSummary } from "@types"
import PriceBadge from "./PriceBadge"
import RatingBadge from "./RatingBadge"

const ProductItem = ({
  name,
  brandName,
  brandSlug,
  minPrice,
  maxPrice,
  averageRating,
  reviewCount,
  inStock,
  thumbnailUrl,
}: ProductSummary) => {
  return (
    <div className="relative p-2 flex flex-col gap-1">
      {!inStock && (
        <p className="absolute top-8 right-8 text-white text-sm px-2 py-0.5 font-medium rounded-xl bg-black">
          Out of Stock
        </p>
      )}
      <div className="py-6 flex-1">
        <img
          src={thumbnailUrl}
          className="mix-blend-darken mx-auto w-full h-full object-contain"
        />
      </div>
      <p className="text-neutral-500">{brandName}</p>
      <p className="text-xl font-medium">{name}</p>
      <PriceBadge minPrice={minPrice} maxPrice={maxPrice} />
      <RatingBadge averageRating={averageRating} reviewCount={reviewCount} />
      <div></div>
    </div>
  )
}
export default ProductItem
