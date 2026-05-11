import { IconStarEmpty, IconStarFilled, IconStarHalf } from "@components"
import { twMerge } from "tailwind-merge"

const getStars = (rating: number) => {
  return Array.from({ length: 5 }, (_, i) => {
    const diff = rating - i

    if (diff >= 1) {
      return "full"
    }
    if (diff >= 0.5) {
      return "half"
    }
    return "empty"
  })
}

interface RatingBadgeProps extends React.ComponentProps<"div"> {
  starsClassName?: string
  averageRating: number
  reviewCount: number
  showLabel?: boolean
}
const RatingBadge = ({
  starsClassName,
  averageRating,
  reviewCount,
  showLabel = true,
  className,
  ...props
}: RatingBadgeProps) => {
  const stars = getStars(averageRating)

  return (
    <div
      className={twMerge("flex gap-1 items-center text-sm", className)}
      {...props}
    >
      {stars.map((type, i) => {
        if (type === "full") {
          return (
            <IconStarFilled
              className={twMerge("size-3.5", starsClassName)}
              key={i}
            />
          )
        }
        if (type === "half") {
          return (
            <IconStarHalf
              className={twMerge("size-3.5", starsClassName)}
              key={i}
            />
          )
        }
        return (
          <IconStarEmpty
            className={twMerge("size-3.5", starsClassName)}
            key={i}
          />
        )
      })}
      {showLabel && (
        <p>
          <span>{averageRating.toPrecision(2)} </span>
          <span className="text-neutral-900">({reviewCount})</span>
        </p>
      )}
    </div>
  )
}
export default RatingBadge
