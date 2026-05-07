import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import categoryApi from "./api/CategoryApi"

interface TopCategoriesProps {
  count: number
}
const useTopCategories = ({ count }: TopCategoriesProps) => {
  const { data } = useQuery({
    queryKey: ["top-categories"],
    queryFn: () => handleQueryFn(() => categoryApi.getTopCategories(count)),
  })
  return { data }
}
export default useTopCategories
