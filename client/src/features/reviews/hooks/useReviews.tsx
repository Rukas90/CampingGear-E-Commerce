import { handleQueryFn } from "@lib"
import type { ReviewsRequest } from "@types"
import reviewsApi from "../api/reviewsApi"
import { useQuery } from "@tanstack/react-query"

const useReviews = ({
  slug,
  ...request
}: ReviewsRequest & { slug: string }) => {
  const query = useQuery({
    queryKey: ["reviews", slug, request],
    queryFn: () => handleQueryFn(() => reviewsApi.queryReviews(slug, request)),
  })

  console.log(slug, request)

  return { reviews: query.data, ...query }
}
export default useReviews
