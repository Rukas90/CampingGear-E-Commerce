export type FilterValue = {
  count: number
} & NameSlug

export type OptionFilter = {
  sortOrder: number
  previewType?: PreviewType
  previewValue?: string
} & FilterValue

export type OptionGroupFilter = {
  sortOrder: number
  options: OptionFilter[]
} & Omit<FilterValue, "count">

export type CatalogFilters = {
  brands: FilterValue[]
  categories: FilterValue[]
  options: OptionGroupFilter[]
  minPrice: number
  maxPrice: number
  inStock: number
  outOfStock: number
}
