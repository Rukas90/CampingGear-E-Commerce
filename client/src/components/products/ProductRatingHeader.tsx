import { RatingBadge } from "@components"
import ReviewsFilterPicker from "./ReviewsFilterPicker"
import { useProductView } from "@features"
import type { StarRating } from "@types"
import RecommendedInfo from "./RecommendedInfo"

const DEFAULT_STAR_COUNTS: Record<StarRating, number> = {
  1: 0,
  2: 0,
  3: 0,
  4: 0,
  5: 0,
}

const ProductRatingHeader = () => {
  const { data } = useProductView()

  return (
    <div className="grid grid-cols-3">
      <div>
        <p className="mb-4 text-sm">Overall Rating</p>
        <RatingBadge
          averageRating={data?.averageRating ?? 0}
          reviewCount={data?.reviewCount ?? 0}
          className="text-lg mb-1"
          starsClassName="size-4.5"
        />
        <RecommendedInfo
          count={data?.recommendedCount ?? 0}
          total={data?.reviewCount ?? 0}
        />
      </div>
      <div className="mx-auto">
        <p className="mb-4 text-sm">Select a row below to filter reviews.</p>
        <ReviewsFilterPicker
          starCounts={data?.starCounts ?? DEFAULT_STAR_COUNTS}
        />
      </div>

      <div className="mx-auto">
        <p className="mb-4 text-sm">Review this Product</p>
        <button className="px-8 py-2 bg-black text-white rounded-lg">
          Write a Review
        </button>
        <p></p>
      </div>
    </div>
  )
}
export default ProductRatingHeader
