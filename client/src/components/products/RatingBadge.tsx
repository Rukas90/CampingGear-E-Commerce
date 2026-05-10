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
}
const RatingBadge = ({
  starsClassName,
  averageRating,
  reviewCount,
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
      {averageRating} <p className="text-neutral-900">({reviewCount})</p>
    </div>
  )
}
export default RatingBadge
