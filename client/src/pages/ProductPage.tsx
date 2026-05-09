import {
  Line,
  PageWrapper,
  ProductHeader,
  ProductImageViewer,
} from "@components"
import { ProductViewProvider } from "@features"
import { useNavigate, useParams } from "react-router-dom"

const ProductPage = () => {
  const { slug } = useParams()
  const navigate = useNavigate()

  if (!slug) {
    navigate("not-found")
    return
  }

  return (
    <ProductViewProvider slug={slug}>
      <PageWrapper className="flex gap-12 my-12 w-full grow">
        <div className="grow max-w-4/7 shrink-0 ">
          <ProductImageViewer />
        </div>
        <div className="flex-1 min-w-0 py-4">
          <ProductHeader />
          <Line className="my-4" />
        </div>
      </PageWrapper>
    </ProductViewProvider>
  )
}
export default ProductPage
