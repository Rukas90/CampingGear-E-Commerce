import type { CustomerId, OptionId } from "./id"
import { NameSlug } from "./base"
import { PreviewType } from "./enums"

export type ProductSortBy =
  | "Manual"
  | "MostRelevant"
  | "BestSelling"
  | "TitleAscending"
  | "TitleDescending"
  | "PriceAscending"
  | "PriceDescending"

export type ProductSummary = {
  brandName: string
  brandSlug: string
  categoryName: string
  categorySlug: string
  minPrice: number
  maxPrice: number
  averageRating: number
  reviewCount: number
  inStock: boolean
  thumbnailUrl: string
} & NameSlug

export type ProductDetail = {
  recommendedCount: number
  starCounts: Record<StarRating, number>
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
  sortOrder: number
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

export type ProductStock = "InStock" | "LowStock" | "OutOfStock"
