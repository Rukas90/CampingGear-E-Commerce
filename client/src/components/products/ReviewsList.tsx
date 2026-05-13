import { useReviews } from "@features"
import type { ReviewsRequest } from "@types"
import ReviewItem from "./ReviewItem"
import { Line } from "@components"

interface ReviewsListProps extends ReviewsRequest {
  slug: string
}
const ReviewsList = ({ slug, ...request }: ReviewsListProps) => {
  const { reviews } = useReviews({ slug, ...request })

  return (
    <div>
      {(reviews?.length ?? 0) > 0 && <Line className="my-8" />}
      {reviews?.map((review, index) => {
        return (
          <div key={review.id}>
            <ReviewItem data={review} />
            {index < reviews.length - 1 && <Line className="my-4" />}
          </div>
        )
      })}
    </div>
  )
}

export default ReviewsList
