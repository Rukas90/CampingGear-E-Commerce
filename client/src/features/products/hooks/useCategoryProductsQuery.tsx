import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import productsApi from "../api/productsApi"
import { parseQuery, type ParseQueryData } from "@features"
import type { ProductsQueryRequest } from "@types"

const useCategoryProductsQuery = (
  queryData: ParseQueryData<ProductsQueryRequest>,
) => {
  const request = parseQuery({ ...queryData })

  const query = useQuery({
    queryKey: ["products", request],
    queryFn: () => handleQueryFn(() => productsApi.queryProducts(request)),
  })

  return { products: query.data, ...query }
}
export default useCategoryProductsQuery
