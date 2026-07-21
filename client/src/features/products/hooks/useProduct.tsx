import { HandleReqFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import productsApi from "../api/productsApi"

const useProduct = (slug: string) => {
  const query = useQuery({
    queryKey: ["products", slug],
    queryFn: () => HandleReqFn(() => productsApi.fetchProduct(slug)),
    staleTime: 1000 * 60 * 15,
  })

  return { products: query.data, ...query }
}
export default useProduct
