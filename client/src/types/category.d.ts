import type { NameSlug } from "./base"
import type { CategoryId } from "./id"

export type Category = {
  id: CategoryId
  description?: string
  groupSlug: string
  imageUrl?: string
} & NameSlug

export type CategoryGroup = {
  sortOrder: number
} & NameSlug
