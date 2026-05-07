import { IconStarEmpty, IconStarFilled, IconStarHalf } from "@components"
import clsx from "clsx"

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
  averageRating: number
  reviewCount: number
}
const RatingBadge = ({
  averageRating,
  reviewCount,
  className,
  ...props
}: RatingBadgeProps) => {
  const stars = getStars(averageRating)

  return (
    <div className={clsx("flex gap-1 items-center", className)} {...props}>
      {stars.map((type, i) => {
        if (type === "full") {
          return <IconStarFilled className="size-3.5" key={i} />
        }
        if (type === "half") {
          return <IconStarHalf className="size-3.5" key={i} />
        }
        return <IconStarEmpty className="size-3.5" key={i} />
      })}
      <p className="text-sm text-neutral-900">({reviewCount})</p>
    </div>
  )
}
export default RatingBadge
