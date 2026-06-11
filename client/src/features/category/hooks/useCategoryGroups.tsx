import { useQuery } from "@tanstack/react-query"
import categoryApi from "../api/CategoryApi"
import { HandleReqFn } from "@lib"

const useCategoryGroups = () => {
  const { data } = useQuery({
    queryKey: ["category-groups"],
    queryFn: () => HandleReqFn(() => categoryApi.getAllCategoryGroups()),
  })
  return { data }
}
export default useCategoryGroups
