import productsApi from "../api/productsApi"
import type { ProductsQueryRequest } from "@types"
import { useQueryHandler, type QueryOptions } from "@features"

const useProductsQuery = (
  request: ProductsQueryRequest,
  options?: QueryOptions,
) => {
  const query = useQueryHandler({
    key: ["products", request],
    func: () => productsApi.queryProducts(request),
    ...options,
    staleTime: 1000 * 60 * 15,
  })

  return { products: query.data, ...query }
}
export default useProductsQuery
