import { FilterContent, FilterToggle, FoldoutContent } from "@components"
import type { OptionGroupFilter } from "@types"

const CatalogOptionsFilter = ({
  name,
  slug,
  options,
}: Omit<OptionGroupFilter, "sortOrder">) => {
  return (
    <FoldoutContent label={name} opened>
      <FilterContent>
        {options
          .sort((a, b) => a.sortOrder - b.sortOrder)
          .map((option) => (
            <FilterToggle
              key={`${slug}_${option.slug}`}
              filterKey={`option[${slug}]`}
              {...option}
            />
          ))}
      </FilterContent>
    </FoldoutContent>
  )
}
export default CatalogOptionsFilter
