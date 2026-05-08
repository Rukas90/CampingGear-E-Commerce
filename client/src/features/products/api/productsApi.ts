import { makeRequest } from "@lib"
import type {
  ProductDetail,
  ProductsQueryRequest,
  ProductSummary,
} from "@types"

const productsApi = {
  queryProducts: async (request: ProductsQueryRequest) => {
    const params = new URLSearchParams()

    Object.entries(request).forEach(([key, value]) => {
      if (value === undefined || value === null) return

      if (key === "option" && typeof value === "object") {
        Object.entries(value as Record<string, string>).forEach(
          ([optKey, optValue]) => {
            params.append(`option[${optKey}]`, optValue)
          },
        )
      } else {
        params.append(key, value.toString())
      }
    })

    return await makeRequest<ProductSummary[]>(
      `api/v1/products?${params.toString()}`,
    )
  },

  fetchProduct: async (slug: string) => {
    return await makeRequest<ProductDetail>(`api/v1/products/${slug}`)
  },
}
export default productsApi
