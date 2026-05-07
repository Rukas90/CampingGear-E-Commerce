import { makeRequest } from "@lib"
import type { CatalogFilters, FiltersQueryRequest } from "@types"

const filtersApi = {
  queryFilters: async (request: FiltersQueryRequest) => {
    const params = new URLSearchParams()

    Object.entries(request).forEach(([key, value]) => {
      if (value === undefined || value === null) {
        return
      }
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

    return await makeRequest<CatalogFilters>(
      `api/v1/filters?${params.toString()}`,
    )
  },
}
export default filtersApi
