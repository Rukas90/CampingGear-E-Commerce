import { FilterContent, FilterToggle, FoldoutContent } from "@components"
import type { FilterValue } from "@types"

const CatalogBrandFilter = ({ brands }: { brands: FilterValue[] }) => {
  return (
    <FoldoutContent label="Brand" opened>
      <FilterContent>
        {brands.map((brand) => (
          <FilterToggle key={brand.slug} filterKey="brand" {...brand} />
        ))}
      </FilterContent>
    </FoldoutContent>
  )
}
export default CatalogBrandFilter
