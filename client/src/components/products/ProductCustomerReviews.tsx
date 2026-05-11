import { Line, PageWrapper } from "@components"
import ProductRatingHeader from "./ProductRatingHeader"
import ProductReviewItem from "./ProductReviewItem"

const ProductCustomerReviews = () => {
  return (
    <div id="#customer-reviews">
      <PageWrapper>
        <p className="text-xl mb-4">Customer Reviews</p>
        <ProductRatingHeader />
        <Line className="my-8" />
        <ProductReviewItem />
        <Line className="my-4" />
        <ProductReviewItem />
        <Line className="my-4" />
        <ProductReviewItem />
        <Line className="my-4" />
        <ProductReviewItem />
        <Line className="my-4" />
        <ProductReviewItem />
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
