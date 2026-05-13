import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import categoryApi from "./api/CategoryApi"
import type { Category, ProblemDetails } from "@types"

const useCategories = () => {
  const { data } = useQuery<Category[], ProblemDetails>({
    queryKey: ["categories"],
    queryFn: async () => handleQueryFn(() => categoryApi.getAllCategories()),
  })
  return { data }
}
export default useCategories
