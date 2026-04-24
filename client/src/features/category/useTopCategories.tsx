import { makeRequest } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { Category } from "@types"

interface TopCategoriesProps {
  count: number
}
const useTopCategories = ({ count }: TopCategoriesProps) => {
  const { data } = useQuery({
    queryKey: ["top-categories"],
    queryFn: async () => {
      const res = await makeRequest<Category[]>(
        `api/v1/categories/top?count=${count}`,
      )
      if (!res.isSuccess) throw res.error
      return res.data
    },
  })
  return { data }
}
export default useTopCategories
