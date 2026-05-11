import type { ProductSummary } from "@types"
import PriceBadge from "./PriceBadge"
import OutOfStockTag from "./OutOfStockTag"
import { RatingBadge, IconCart, IconSaved } from "@components"
import { Link } from "react-router-dom"

const ProductItem = ({
  name,
  slug,
  brandName,
  brandSlug,
  minPrice,
  maxPrice,
  averageRating,
  reviewCount,
  inStock,
  thumbnailUrl,
}: ProductSummary) => {
  const link = `/product/${slug}`

  return (
    <div className="relative p-2 flex flex-col gap-1">
      {!inStock && <OutOfStockTag />}
      <div className="py-6 flex-1">
        <Link to={link} target="_self">
          <img
            src={thumbnailUrl}
            className="mix-blend-darken mx-auto w-full h-full object-contain"
          />
        </Link>
      </div>
      <Link to={`/brands/${brandSlug}`} target="_self">
        <p className="text-neutral-500">{brandName}</p>
      </Link>
      <Link to={link} target="_self">
        <p className="text-xl font-medium">{name}</p>
      </Link>
      <PriceBadge minPrice={minPrice} maxPrice={maxPrice} />
      <RatingBadge averageRating={averageRating} reviewCount={reviewCount} />
      <button className="flex gap-2 mt-1.5">
        <IconSaved className="size-5 text-gray-700" />
        <IconCart className="size-5 text-gray-700" />
      </button>
    </div>
  )
}
export default ProductItem
