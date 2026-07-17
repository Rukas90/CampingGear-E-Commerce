import { ProductSortBy } from "./product"
import { Availability, ReviewSortBy } from "./enums"
import type { ReviewSortByType, StarRating } from "./review"
import type { SkuCode } from "./brands"
import type { CartEntry, CartLineItem } from "./cart"
import type { AvailabilityType } from "./filter"

export type ProductsQueryRequest = {
  sortBy?: ProductSortBy
  brand?: string[]
  category?: string[]
  pagination?: boolean
  page?: number
  pageSize?: number
  priceGte?: number
  priceLte?: number
  availability?: AvailabilityType
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
  sortBy: ReviewSortByType
  starFilter?: StarRating
}

export type GetCartSkusRequest = {
  codes: string[]
}

export type UpdateCheckoutContactRequest = {
  emailAddress?: string
}
