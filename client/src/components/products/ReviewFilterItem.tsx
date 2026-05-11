import { RatingStars } from "@components"
import type { StarRating } from "@types"

interface ReviewFilterItemProps {
  rating: StarRating
  count: number
  total: number
}
const ReviewFilterItem = ({ rating, count, total }: ReviewFilterItemProps) => {
  const percentage = total > 0 ? (count / total) * 100 : 0

  return (
    <div className="flex gap-4 items-center">
      <RatingStars rating={rating} />
      <div className="w-34 h-3 rounded-lg bg-[#e0dedc] overflow-hidden">
        <div
          className="h-full rounded-lg bg-stone-600"
          style={{ width: `${percentage}%` }}
        />
      </div>
      <p className="text-sm font-medium text-stone-600">{count}</p>
    </div>
  )
}
export default ReviewFilterItem
