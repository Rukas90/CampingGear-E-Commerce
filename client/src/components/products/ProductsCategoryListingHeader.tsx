import { Breadcrumbs } from "@components"
import { useCategories, useCategoryGroups } from "@features"

interface ProductsCategoryListingHeaderProps {
  categorySlug: string
}
const ProductsCategoryListingHeader = ({
  categorySlug,
}: ProductsCategoryListingHeaderProps) => {
  const { data: categories } = useCategories()
  const { data: groups } = useCategoryGroups()

  if (!categories || !groups) {
    return <></>
  }
  const category = categories.find((c) => c.slug === categorySlug)
  const group = groups.find((c) => c.slug === category?.groupSlug)

  if (!category || !group) {
    return <></>
  }

  return (
    <div>
      <Breadcrumbs
        items={[
          { name: "Home", link: "/" },
          { name: group.name, link: "/" },
          { name: category.name, link: "#", disabled: true },
        ]}
      />
      <p className="text-4xl font-medium">{category.name}</p>
      <p>{category.description}</p>
    </div>
  )
}
export default ProductsCategoryListingHeader
