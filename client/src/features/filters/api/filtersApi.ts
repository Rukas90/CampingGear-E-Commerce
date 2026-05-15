import { recordMapper, reqToParams } from "@features"
import { makeRequest } from "@lib"
import type { CatalogFilters, FiltersQueryRequest } from "@types"

const filtersApi = {
  queryFilters: async (request: FiltersQueryRequest) => {
    const params = reqToParams(request, {
      option: recordMapper,
    })
    return await makeRequest<CatalogFilters>(`api/v1/filters?${params}`)
  },
}
export default filtersApi
