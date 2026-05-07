import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import categoryApi from "./api/CategoryApi"

const useCategories = () => {
  const { data } = useQuery({
    queryKey: ["categories"],
    queryFn: async () => handleQueryFn(() => categoryApi.getAllCategories()),
  })
  return { data }
}
export default useCategories
