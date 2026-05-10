import { Breadcrumbs } from "@components"
import { useProductView } from "@features"

const ProductBreadcrumbs = () => {
  const { data } = useProductView()

  if (!data) {
    return
  }

  return (
    <Breadcrumbs
      items={[
        { name: "Home", link: "/" },
        { name: data.categoryName, link: `/products/${data.categorySlug}` },
        { name: data.name, link: `/product/${data.slug}`, disabled: true },
      ]}
    />
  )
}
export default ProductBreadcrumbs
