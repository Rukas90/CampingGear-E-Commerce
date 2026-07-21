import { useQueryHandler, type QueryOptions } from "@features"
import countriesApi from "../api/countriesApi"
import type { Country } from "@types"

const useCountries = (options?: QueryOptions) => {
  const query = useQueryHandler({
    key: ["countries"],
    func: () => countriesApi.getCountries(),
    ...options,
    select: (data) => data.toSorted((a, b) => a.name.localeCompare(b.name)),
    staleTime: Infinity,
    gcTime: Infinity,
  })

  const findByCode = (code?: string): Country | undefined => {
    if (!code) {
      return undefined
    }
    return query.data?.find((c) => c.code.toLowerCase() === code.toLowerCase())
  }

  return {
    findByCode,
    ...query,
  }
}
export default useCountries
