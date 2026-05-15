import {
  PageWrapper,
  ProductSummary,
  ProductImageViewer,
  ProductOptionPicker,
  ProductPurchase,
  ProductTrustMessages,
  ProductBreadcrumbs,
  ProductDescription,
  Line,
  ProductCustomerReviews,
} from "@components"
import { ProductViewProvider } from "@features"
import { useNavigate, useParams } from "react-router-dom"

const ProductPage = () => {
  const { slug } = useParams()
  const navigate = useNavigate()

  if (!slug) {
    navigate("/not-found")
    return
  }

  return (
    <ProductViewProvider slug={slug}>
      <PageWrapper className="my-12 w-full">
        <div className="mb-8">
          <ProductBreadcrumbs />
        </div>
        <div className="flex md:flex-row flex-col gap-12 w-full grow">
          <div className="grow md:max-w-4/7 w-full shrink-0 ">
            <ProductImageViewer />
          </div>
          <div className="flex-1 min-w-0 py-4">
            <ProductSummary />
            <ProductOptionPicker />
            <ProductPurchase />
            <ProductTrustMessages />
          </div>
        </div>
      </PageWrapper>
      <div className="bg-stone-100 py-8">
        <Line className="mb-8" />
        <PageWrapper>
          <ProductDescription />
        </PageWrapper>
        <Line className="my-8" />
        <ProductCustomerReviews />
      </div>
    </ProductViewProvider>
  )
}
export default ProductPage
