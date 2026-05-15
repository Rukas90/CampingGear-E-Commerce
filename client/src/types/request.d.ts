import { ProductSortBy } from "./product"
import { Availability, ReviewSortBy } from "./enums"
import type { StarRating } from "./review"
import type { SkuCode } from "./id"

export type ProductsQueryRequest = {
  sortBy?: ProductSortBy
  brand?: string[]
  category?: string[]
  pagination?: boolean
  page?: number
  pageSize?: number
  priceGte?: number
  priceLte?: number
  availability?: Availability
  option?: Record<string, string>
  skuCode?: SkuCode[]
}

export type FiltersQueryRequest = Omit<
  ProductsQueryRequest,
  "sortBy" | "pagination" | "page" | "pageSize"
> & {
  queryBrand?: string
  queryCategory?: string
}

export type ReviewsRequest = {
  page?: number
  pageSize?: number
  sortBy: ReviewSortBy
  filter?: StarRating
}

export type GetCartSkusRequest = {
  codes: string[]
}
