import { Line, PageWrapper } from "@components"
import ProductRatingHeader from "./ProductRatingHeader"
import { useProductView } from "@features"
import ReviewsList from "./ReviewsList"
import { useState } from "react"
import { ReviewSortBy, type StarRating } from "@types"

const ProductCustomerReviews = () => {
  const [filter, setFilter] = useState<StarRating | undefined>(undefined)

  const { data } = useProductView()

  return (
    <div id="#customer-reviews">
      <PageWrapper>
        <p className="text-xl mb-4">Customer Reviews</p>
        <ProductRatingHeader />
        {data ? (
          <ReviewsList
            slug={data.slug}
            filter={filter}
            sortBy={ReviewSortBy.MostRecent}
          />
        ) : (
          <p>No reviews found.</p>
        )}
      </PageWrapper>

      <Line className="my-4" />

      <PageWrapper>
        <ul className="flex gap-4 justify-center my-8">
          <li className="text-lg flex items-center justify-center border border-neutral-300 size-8 rounded-full bg-stone-100">
            1
          </li>
          <li className="text-lg text-stone-400">2</li>
        </ul>
      </PageWrapper>
    </div>
  )
}
export default ProductCustomerReviews
