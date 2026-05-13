import {
  IconAccount,
  IconThumbUp,
  RatingStars,
  RecommendBadge,
} from "@components"
import type { Review } from "@types"

interface ReviewProps {
  data: Review
}
const ReviewItem = ({ data }: ReviewProps) => {
  return (
    <div className="flex flex-col gap-4 py-4">
      <div className="flex justify-between">
        <RatingStars rating={data.rating} className="size-4" />
        <p className="text-sm text-stone-400">
          {new Date(data.createdAt).toLocaleDateString("en-US", {
            month: "short",
            day: "numeric",
            year: "numeric",
          })}
        </p>
      </div>

      <div className="flex gap-2.5 text-lg">
        <div className="bg-stone-200 size-10 rounded-lg p-1.5">
          <IconAccount className="text-stone-400" />
        </div>
        <p className="text-stone-800">
          {data.customerFirstName} {data.customerLastName}
        </p>
      </div>

      <p className="text-[1.175rem] font-medium">{data.headline}</p>
      <RecommendBadge
        recommended={data.recommended}
        yesText="Yes, I recommend this product."
        noText="No, I do not recommend this product."
      />
      <p>{data.text}</p>
      <div className="flex gap-4 justify-end">
        <div className="flex gap-2 items-center">
          <IconThumbUp className="size-5.5 text-stone-800" />
          <p className="text-base pt-1">{data.likes}</p>
        </div>
        <div className="flex gap-2 items-center">
          <IconThumbUp className="size-5.5 rotate-180 mt-1 text-stone-800" />
          <p className="text-base pt-1">{data.dislikes}</p>
        </div>
      </div>
    </div>
  )
}
export default ReviewItem
