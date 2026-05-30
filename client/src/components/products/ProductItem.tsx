import type { ProductSummary } from "@types"
import PriceBadge from "./PriceBadge"
import OutOfStockTag from "./OutOfStockTag"
import { RatingBadge, IconSaved } from "@components"
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
        <a href={link} target="_self">
          <img
            src={thumbnailUrl}
            className="mix-blend-darken mx-auto w-full h-full object-contain"
          />
        </a>
      </div>
      <Link to={`/brands/${brandSlug}`} target="_self">
        <p className="text-neutral-500">{brandName}</p>
      </Link>
      <a href={link} target="_self">
        <p className="text-xl font-medium">{name}</p>
      </a>
      <PriceBadge minPrice={minPrice} maxPrice={maxPrice} />
      <RatingBadge averageRating={averageRating} reviewCount={reviewCount} />
      <div className="flex gap-2 mt-1.5">
        <IconSaved className="size-5 text-gray-700" />
      </div>
    </div>
  )
}
export default ProductItem
