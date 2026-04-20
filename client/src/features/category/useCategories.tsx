import { makeRequest } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { Category } from "@types"

const useCategories = () => {
  const { data } = useQuery({
    queryKey: ["categories"],
    queryFn: async () => {
      const res = await makeRequest<Category[]>("api/v1/categories")
      if (!res.isSuccess) throw res.error
      return res.data
    },
  })
  return { data }
}
export default useCategories
