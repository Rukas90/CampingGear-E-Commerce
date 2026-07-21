import { useCategories } from "@features"
import ContrastButton from "./ContrastButton"
import { useNavigate } from "react-router-dom"

const BrowseProductsButton = () => {
  const { data } = useCategories()
  const navigate = useNavigate()

  const handleBrowseClick = () => {
    const randomCategory = data?.length
      ? data[Math.floor(Math.random() * data.length)]
      : null

    navigate(randomCategory ? `/products/${randomCategory.slug}` : "/")
  }

  return (
    <ContrastButton className="mx-auto py-2.5 px-4" onClick={handleBrowseClick}>
      Browse products
    </ContrastButton>
  )
}
export default BrowseProductsButton
