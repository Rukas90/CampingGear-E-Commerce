import { recordMapper, reqToParams } from "@features"
import { makeRequest } from "@lib"
import type {
  ProductDetail,
  ProductsQueryRequest,
  ProductSummary,
} from "@types"

const productsApi = {
  queryProducts: async (request: ProductsQueryRequest) => {
    const params = reqToParams(request, {
      option: recordMapper,
    })
    return await makeRequest<ProductSummary[]>(`api/v1/products?${params}`)
  },

  fetchProduct: async (slug: string) => {
    return await makeRequest<ProductDetail>(`api/v1/products/${slug}`)
  },
}
export default productsApi
