import { FilterContent, FoldoutContent, RangeSlider } from "@components"
import type { CatalogFilters, ProductsQueryRequest } from "@types"
import { useState } from "react"
import { useSearchParams } from "react-router-dom"

const PRICE_KEYS: Record<"min" | "max", keyof ProductsQueryRequest> = {
  min: "priceGte",
  max: "priceLte",
}

const CatalogPriceRangeFilter = ({
  minPrice,
  maxPrice,
}: Pick<CatalogFilters, "minPrice" | "maxPrice">) => {
  const [searchParams, setSearchParams] = useSearchParams()
  const [price, setPrice] = useState<[number, number]>([
    Number(searchParams.get(PRICE_KEYS.min)) || minPrice,
    Number(searchParams.get(PRICE_KEYS.max)) || maxPrice,
  ])

  const handleChange = ([newMin, newMax]: [number, number]) => {
    setPrice([newMin, newMax])

    setSearchParams((prev) => {
      if (newMin === minPrice) {
        prev.delete(PRICE_KEYS.min)
      } else {
        prev.set(PRICE_KEYS.min, newMin.toString())
      }
      if (newMax === maxPrice) {
        prev.delete(PRICE_KEYS.max)
      } else {
        prev.set(PRICE_KEYS.max, newMax.toString())
      }
      return prev
    })
  }

  const [selectedMinPrice, selectedMaxPrice] = price

  return (
    <FoldoutContent label="Price" opened>
      <FilterContent className="px-2.5">
        <RangeSlider
          min={minPrice}
          max={maxPrice}
          defaultValue={price}
          onChange={handleChange}
          onChanging={setPrice}
        />
        <div className="flex justify-between">
          <p className="text-sm text-neutral-400">€{selectedMinPrice}</p>
          <p className="text-sm text-neutral-400">€{selectedMaxPrice}</p>
        </div>
      </FilterContent>
    </FoldoutContent>
  )
}
export default CatalogPriceRangeFilter
