import { useProduct } from "@features"
import { useNavigate, useParams } from "react-router-dom"

const ProductPage = () => {
  const { slug } = useParams()
  const navigate = useNavigate()

  if (!slug) {
    navigate("/not-found")
    return
  }
  const { data, isFetched } = useProduct(slug)

  if (!data) {
    return
  }

  const { skus } = data

  return <div></div>
}
export default ProductPage
