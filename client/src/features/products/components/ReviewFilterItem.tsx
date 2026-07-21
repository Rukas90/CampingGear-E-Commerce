import { RatingStars } from "@features"
import type { StarRating } from "@types"
import clsx from "clsx"

interface ReviewFilterItemProps {
  rating: StarRating
  count: number
  total: number
  selected: boolean
  onSelect: (rating: StarRating) => void
  onDeselect: () => void
}
const ReviewFilterItem = ({
  rating,
  count,
  total,
  selected,
  onSelect,
  onDeselect,
}: ReviewFilterItemProps) => {
  const percentage = total > 0 ? (count / total) * 100 : 0

  const handleClick = () => {
    if (count <= 0) {
      return
    }
    if (!selected) {
      onSelect(rating)

      return
    }
    onDeselect()
  }

  return (
    <button
      onClick={handleClick}
      className="group flex gap-4 items-center cursor-pointer"
    >
      <RatingStars
        rating={rating}
        className={clsx(
          !selected && "opacity-90 group-hover:opacity-100",
          selected && "opacity-100",
        )}
      />
      <div className="lg:w-34 w-full h-3 rounded-lg bg-[#e0dedc] group-hover:bg-[#e6e4e2] overflow-hidden">
        <div
          className={clsx(
            "h-full rounded-lg group-hover:bg-stone-600",
            !selected && "bg-[#AFB9A4]",
            selected && "bg-neutral-800",
          )}
          style={{ width: `${percentage}%` }}
        />
      </div>
      <p
        className={clsx(
          "text-sm group-hover:underline font-medium",
          selected && "underline text-neutral-800",
          !selected && "text-accent",
        )}
      >
        {count}
      </p>
    </button>
  )
}
export default ReviewFilterItem
