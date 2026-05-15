import type { ProductsQueryRequest, ProductSortBy, SkuCode } from "@types"

export interface ParseQueryData<T extends ProductsQueryRequest> {
  searchParams: URLSearchParams
  overrides?: Partial<T>
  exclude?: (keyof ProductsQueryRequest)[]
}

const parseQuery = <T extends ProductsQueryRequest>({
  searchParams,
  overrides,
  exclude,
}: ParseQueryData<T>): T => {
  const request: ProductsQueryRequest = {
    sortBy: (searchParams.get("sortBy") as ProductSortBy) ?? undefined,
    brand:
      searchParams.getAll("brand").length > 0
        ? searchParams.getAll("brand")
        : undefined,
    category:
      searchParams.getAll("category").length > 0
        ? searchParams.getAll("category")
        : undefined,
    pagination: !!searchParams.get("page"),
    page: Number(searchParams.get("page")) || undefined,
    pageSize: 20,
    priceGte: Number(searchParams.get("priceGte")) || undefined,
    priceLte: Number(searchParams.get("priceLte")) || undefined,
    availability: Number(searchParams.get("availability")) || undefined,
    option: Object.fromEntries(
      [...searchParams.entries()]
        .filter(([key]) => key.startsWith("option["))
        .map(([key, value]) => [key.slice(7, -1), value]),
    ),
    skuCode:
      searchParams.getAll("skuCodes").length > 0
        ? (searchParams.getAll("skuCodes") as SkuCode[])
        : undefined,
    ...overrides,
  }

  exclude?.forEach((key) => delete request[key])

  return request as T
}
export default parseQuery
