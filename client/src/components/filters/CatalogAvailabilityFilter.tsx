import { FilterContent, FilterToggle, FoldoutContent } from "@components"
import { Availability, type CatalogFilters } from "@types"

const CatalogAvailabilityFilter = ({
  inStock,
  outOfStock,
}: Pick<CatalogFilters, "inStock" | "outOfStock">) => {
  return (
    <FoldoutContent label="Availability" opened>
      <FilterContent>
        <FilterToggle
          filterKey="availability"
          name="In Stock"
          slug={Number(Availability.InStock).toString()}
          count={inStock ?? 0}
          selectionMode="replace"
        />
        <FilterToggle
          filterKey="availability"
          name="Out of Stock"
          slug={Number(Availability.OutOfStock).toString()}
          count={outOfStock ?? 0}
          selectionMode="replace"
        />
      </FilterContent>
    </FoldoutContent>
  )
}
export default CatalogAvailabilityFilter
