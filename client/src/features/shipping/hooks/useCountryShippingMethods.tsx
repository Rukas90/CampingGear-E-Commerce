import { useQueryHandler, type QueryOptions } from "@features"
import shippingApi from "../api/shippingApi"

const useCountryShippingMethods = (
  countryCode?: string,
  options?: QueryOptions,
) => {
  const query = useQueryHandler({
    key: ["country-shipping-methods", countryCode],
    func: () => shippingApi.getCountryShippingMethods(countryCode),
    staleTime: Infinity,
    gcTime: Infinity,
    ...options,
  })

  return { availableMethods: query.data ?? [], ...query }
}
export default useCountryShippingMethods
