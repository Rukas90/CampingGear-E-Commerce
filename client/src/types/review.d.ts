export type StarRating = 1 | 2 | 3 | 4 | 5

export type Review = {
  id: ReviewId
  customerFirstName: string
  customerLastName: string
  rating: StarRating
  createdAt: Date
  headline: string
  text: string
  recommended: boolean
  likes: number
  dislikes: number
}
