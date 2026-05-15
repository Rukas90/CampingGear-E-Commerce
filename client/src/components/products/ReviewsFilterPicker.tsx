import type { StarRating } from "@types"
import ReviewFilterItem from "./ReviewFilterItem"

interface ReviewsFilterPickerProps {
  starCounts: Record<StarRating, number>
}
const ReviewsFilterPicker = ({ starCounts }: ReviewsFilterPickerProps) => {
  const total = Object.values(starCounts).reduce((sum, count) => sum + count, 0)

  return (
    <div className="flex flex-col gap-1.5">
      {(Object.keys(starCounts) as unknown as StarRating[])
        .sort((a, b) => b - a)
        .map((star) => (
          <ReviewFilterItem
            key={star}
            rating={star}
            count={starCounts[star]}
            total={total}
          />
        ))}
    </div>
  )
}
export default ReviewsFilterPicker
