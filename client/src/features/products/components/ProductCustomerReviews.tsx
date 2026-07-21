import ProductRatingHeader from "./ProductRatingHeader"
import { PageWrapper, ProductReviewsProvider, useProductView } from "@features"
import ReviewsList from "./ReviewsList"

const ProductCustomerReviews = () => {
  const { data } = useProductView()

  return (
    <ProductReviewsProvider slug={data?.slug}>
      <PageWrapper>
        <p className="text-xl mb-4">Customer Reviews</p>
        <ProductRatingHeader />
        {data ? <ReviewsList /> : <p>No reviews found.</p>}
      </PageWrapper>
    </ProductReviewsProvider>
  )
}
export default ProductCustomerReviews
