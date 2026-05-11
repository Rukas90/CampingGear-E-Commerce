import { IconStarEmpty, IconStarFilled, IconStarHalf } from "@components"
import { twMerge } from "tailwind-merge"

interface RatingStarsProps {
  className?: string
  rating: number
}

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

const RatingStars = ({ className, rating }: RatingStarsProps) => {
  const stars = getStars(rating)

  return (
    <div className="flex gap-1">
      {stars.map((type, i) => {
        if (type === "full") {
          return (
            <IconStarFilled
              className={twMerge("size-3.5", className)}
              key={i}
            />
          )
        }
        if (type === "half") {
          return (
            <IconStarHalf className={twMerge("size-3.5", className)} key={i} />
          )
        }
        return (
          <IconStarEmpty className={twMerge("size-3.5", className)} key={i} />
        )
      })}
    </div>
  )
}
export default RatingStars
