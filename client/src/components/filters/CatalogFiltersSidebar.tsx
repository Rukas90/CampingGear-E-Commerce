import { type CatalogFilters } from "@types"
import CatalogBrandFilter from "./CatalogBrandFilter"
import CatalogCategoryFilter from "./CatalogCategoryFilter"
import CatalogAvailabilityFilter from "./CatalogAvailabilityFilter"
import CatalogPriceRangeFilter from "./CatalogPriceRangeFilter"
import CatalogOptionsFilter from "./CatalogOptionsFilter"

interface CatalogFiltersSidebarProps extends CatalogFilters {
  exclude?: (keyof CatalogFilters)[]
}

const CatalogFiltersSidebar = ({
  categories,
  brands,
  inStock,
  outOfStock,
  minPrice,
  maxPrice,
  options,
  exclude = [],
}: CatalogFiltersSidebarProps) => {
  const isHidden = (key: (typeof exclude)[number]) => exclude.includes(key)

  return (
    <div className="min-w-62 sticky top-22">
      <button className="text-sm text-lime-800 font-medium">
        Clear filters
      </button>
      {!isHidden("categories") && (
        <CatalogCategoryFilter categories={categories} />
      )}

      <div className="w-full h-px bg-stone-200 my-2" />

      {!isHidden("brands") && <CatalogBrandFilter brands={brands} />}

      <div className="w-full h-px bg-stone-200 my-2" />

      <CatalogAvailabilityFilter inStock={inStock} outOfStock={outOfStock} />

      <div className="w-full h-px bg-stone-200 my-2" />

      <CatalogPriceRangeFilter
        key={`${minPrice}-${maxPrice}`}
        minPrice={minPrice}
        maxPrice={maxPrice}
      />

      <div className="w-full h-px bg-stone-200 my-2" />

      {!isHidden("options") &&
        options
          .sort((group) => group.sortOrder)
          .map((group, index) => (
            <div key={group.slug}>
              <CatalogOptionsFilter {...group} />
              {index < options.length - 1 && (
                <div className="w-full h-px bg-stone-200 my-2" />
              )}
            </div>
          ))}
    </div>
  )
}
export default CatalogFiltersSidebar
