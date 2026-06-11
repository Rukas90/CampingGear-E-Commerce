import { HandleReqFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import categoryApi from "../api/CategoryApi"

interface TopCategoriesProps {
  count: number
}
const useTopCategories = ({ count }: TopCategoriesProps) => {
  const { data } = useQuery({
    queryKey: ["top-categories"],
    queryFn: () => HandleReqFn(() => categoryApi.getTopCategories(count)),
  })
  return { data }
}
export default useTopCategories
