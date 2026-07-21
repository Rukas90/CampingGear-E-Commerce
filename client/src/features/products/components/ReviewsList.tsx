import { Line, useProductReviews } from "@features"
import ReviewItem from "./ReviewItem"

const ReviewsList = () => {
  const { reviews } = useProductReviews()

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
