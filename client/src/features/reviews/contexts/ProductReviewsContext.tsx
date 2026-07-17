import {
  ReviewSortBy,
  type Review,
  type ReviewSortByType,
  type ReviewsRequest,
  type StarRating,
} from "@types"
import { createContext, useContext, useState } from "react"
import { useQuery } from "@tanstack/react-query"
import reviewsApi from "../api/reviewsApi"
import { HandleReqFn } from "@lib"

interface ProductReviewsData {
  filter: StarRating | undefined
  reviews: Review[] | undefined
  setStarFilter: (rating: StarRating) => void
  clearStarFilter: () => void
  setSorting: (sort: ReviewSortByType | undefined) => void
}

const ProductReviewsContext = createContext<ProductReviewsData | undefined>(
  undefined,
)

const ProductReviewsProvider = ({
  slug,
  children,
}: React.PropsWithChildren<{ slug?: string }>) => {
  const [starFilter, setStarFilter] = useState<StarRating | undefined>(
    undefined,
  )
  const [sortBy, setSorting] = useState<ReviewSortByType | undefined>(
    ReviewSortBy.MostRecent,
  )
  const request: ReviewsRequest = { sortBy, starFilter }

  const query = useQuery({
    queryKey: ["reviews", slug, request],
    queryFn: () => HandleReqFn(() => reviewsApi.queryReviews(request, slug)),
    enabled: !!slug,
  })

  return (
    <ProductReviewsContext.Provider
      value={{
        filter: starFilter,
        reviews: query.data,
        setStarFilter,
        clearStarFilter: () => setStarFilter(undefined),
        setSorting,
      }}
    >
      {children}
    </ProductReviewsContext.Provider>
  )
}
export default ProductReviewsProvider

export const useProductReviews = () => {
  const context = useContext(ProductReviewsContext)

  if (!context) {
    throw new Error()
  }
  return context
}
