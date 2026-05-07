import { useQuery } from "@tanstack/react-query"
import categoryApi from "./api/CategoryApi"
import { handleQueryFn } from "@lib"

const useCategoryGroups = () => {
  const { data } = useQuery({
    queryKey: ["category-groups"],
    queryFn: () => handleQueryFn(() => categoryApi.getAllCategoryGroups()),
  })
  return { data }
}
export default useCategoryGroups
