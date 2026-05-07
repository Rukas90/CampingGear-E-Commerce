import { handleQueryFn } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { FiltersQueryRequest } from "@types"
import filtersApi from "../api/filtersApi"
import { parseQuery, type ParseQueryData } from "@features"

const useFilters = (queryData: ParseQueryData<FiltersQueryRequest>) => {
  const request = parseQuery<FiltersQueryRequest>({
    ...queryData,
    exclude: ["sortBy", "pagination", "page", "pageSize"],
  })

  const query = useQuery({
    queryKey: ["catalog-filters", request],
    queryFn: () => handleQueryFn(() => filtersApi.queryFilters(request)),
  })

  return { catalogFilters: query.data, ...query }
}
export default useFilters
