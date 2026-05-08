import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import productsApi from "../api/productsApi"

const useProduct = (slug: string) => {
  const query = useQuery({
    queryKey: ["products", slug],
    queryFn: () => handleQueryFn(() => productsApi.fetchProduct(slug)),
  })

  return { products: query.data, ...query }
}
export default useProduct
