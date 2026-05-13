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
    <button className="group flex gap-4 items-center cursor-pointer">
      <RatingStars
        rating={rating}
        className="opacity-90 group-hover:opacity-100"
      />
      <div className="w-34 h-3 rounded-lg bg-[#e0dedc] group-hover:bg-[#e6e4e2] overflow-hidden">
        <div
          className="h-full rounded-lg bg-black group-hover:bg-stone-600"
          style={{ width: `${percentage}%` }}
        />
      </div>
      <p className="text-sm font-medium text-stone-600 group-hover:underline">
        {count}
      </p>
    </button>
  )
}
export default ReviewFilterItem
