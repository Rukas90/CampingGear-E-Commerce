import type { CustomerId } from "./Id"

export type ProductCategory =
  | "handheld-gps"
  | "tents"
  | "backpacks"
  | "sleeping-bags"

export type Cart = {
  customerId: CustomerId
}
export type CartItem = {
  id: CartItemId
}

export type Category = {
  id: CategoryId
  name: string
  description?: string
  groupSlug: string
  slug: string
  imageUrl?: string
}

export type CategoryGroup = {
  name: string
  slug: string
  sortOrder: number
}

export type SortBy =
  | "Manual"
  | "MostRelevant"
  | "BestSelling"
  | "TitleAscending"
  | "TitleDescending"
  | "PriceAscending"
  | "PriceDescending"

export type ProductsQueryRequest = {
  sortBy?: SortBy
  brand?: string[]
  category?: string[]
  pagination?: boolean
  page?: number
  pageSize?: number
  priceGte?: number
  priceLte?: number
  availability?: Availability
  option?: Record<string, string>
}

export type FiltersQueryRequest = Omit<
  ProductsQueryRequest,
  "sortBy" | "pagination" | "page" | "pageSize"
> & {
  queryBrand?: string
  queryCategory?: string
}

export type FilterValue = {
  name: string
  slug: string
  count: number
}

export type OptionFilter = {
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

export type ProductSummary = {
  name: string
  slug: string
  brandName: string
  brandSlug: string
  category: string
  minPrice: number
  maxPrice: number
  averageRating: number
  reviewCount: number
  inStock: boolean
  thumbnailUrl: string
}
