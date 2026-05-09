import type { CustomerId, OptionId } from "./id"

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

export type NameSlug = {
  name: string
  slug: string
}

export type Category = {
  id: CategoryId
  description?: string
  groupSlug: string
  imageUrl?: string
} & NameSlug

export type CategoryGroup = {
  sortOrder: number
} & NameSlug

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

export type ProductSummary = {
  brandName: string
  brandSlug: string
  category: string
  minPrice: number
  maxPrice: number
  averageRating: number
  reviewCount: number
  inStock: boolean
  thumbnailUrl: string
} & NameSlug

export type ProductDetail = {
  description: string
  skus: ProductSku[]
  options: ProductOptionGroup[]
  images: ProductImage[]
} & ProductSummary

export type ProductSku = {
  codeHash: string
  unitPrice: number
  stock: number
  optionIds: OptionId[]
}

export type ProductOptionGroup = {
  name: string
  sortOrder: number
  options: ProductOption[]
}

export type ProductOption = {
  id: OptionId
  name: string
  inStock: boolean
  previewType?: PreviewType
  previewValue?: string
}

export type ProductImage = {
  optionId?: OptionId
  urls: ProductImageUrl[]
}

export type ProductImageUrl = {
  url: string
  sortOrder: number
}
