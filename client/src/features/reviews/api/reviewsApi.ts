import { makeRequest } from "@lib"
import type { Review, ReviewsRequest } from "@types"

const reviewsApi = {
  queryReviews: async (slug: string, request: ReviewsRequest) => {
    const params = new URLSearchParams()

    Object.entries(request).forEach(([key, value]) => {
      if (!value) {
        return
      }
      params.append(key, value.toString())
    })

    return await makeRequest<Review[]>(
      `api/v1/products/${slug}/reviews?${params.toString()}`,
      "get",
    )
  },
}
export default reviewsApi
