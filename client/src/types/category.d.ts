export type Category = {
  id: CategoryId
  description?: string
  groupSlug: string
  imageUrl?: string
} & NameSlug

export type CategoryGroup = {
  sortOrder: number
} & NameSlug
