import { parseQuery, useProductsQuery, type ParseQueryData } from "@features"
import type { ProductsQueryRequest } from "@types"

const useCategoryProductsQuery = (
  queryData: ParseQueryData<ProductsQueryRequest>,
) => {
  const request = parseQuery({ ...queryData })

  return useProductsQuery(request)
}
export default useCategoryProductsQuery
