import { FilterContent, FilterToggle, FoldoutContent } from "@components"
import type { FilterValue } from "@types"

const CatalogCategoryFilter = ({
  categories,
}: {
  categories: FilterValue[]
}) => {
  return (
    <FoldoutContent label="Category" opened>
      <FilterContent>
        {categories.map((category) => (
          <FilterToggle
            key={category.slug}
            filterKey="category"
            {...category}
          />
        ))}
      </FilterContent>
    </FoldoutContent>
  )
}
export default CatalogCategoryFilter
