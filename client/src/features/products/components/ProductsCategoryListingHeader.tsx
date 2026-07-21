import { Breadcrumbs, useCategories, useCategoryGroups } from "@features"

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
      <title>{`Trailstore - Browse - ${category.name}`}</title>
      <Breadcrumbs
        items={[
          { name: "Home", link: "/" },
          { name: group.name, link: "/" },
          { name: category.name, link: "#", disabled: true },
        ]}
      />
      <p className="md:text-4xl sm:text-3xl text-2xl sm:font-medium font-semibold sm:my-0 my-6 sm:text-start text-center">
        {category.name}
      </p>
      <p>{category.description}</p>
    </div>
  )
}
export default ProductsCategoryListingHeader
