import { Spinner } from "@components"
import { useCategories, useCategoryGroups } from "@features"
import type { Category, CategoryGroup } from "@types"
import { Link } from "react-router-dom"

const ProductCatgoryListing = () => {
  const { data: categories } = useCategories()
  const { data: groups } = useCategoryGroups()

  if (!groups || !categories) {
    return <Spinner />
  }

  return (
    <div className="flex gap-10">
      {groups
        .sort((group) => group.sortOrder)
        .map((group) => (
          <Listing
            key={group.slug}
            group={group}
            categories={categories.filter(
              (category) => category.groupSlug === group.slug,
            )}
          />
        ))}
    </div>
  )
}

interface ListingProps {
  group: Omit<CategoryGroup, "sortOrder">
  categories: Pick<Category, "name" | "slug">[]
}

const Listing = ({ group, categories }: ListingProps) => {
  return (
    <div>
      <p className="font-medium mb-1">{group.name}</p>
      <ul>
        {categories.map((category) => (
          <Link key={category.slug} to={`/products/${category.slug}`}>
            <li>{category.name}</li>
          </Link>
        ))}
      </ul>
    </div>
  )
}

export default ProductCatgoryListing
