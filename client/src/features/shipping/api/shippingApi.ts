import { makeRequest } from "@lib"
import type { ShippingMethod } from "@types"
import { ApiOk } from "@utils"

const shippingApi = {
  getCountryShippingMethods: async (countryCode?: string) => {
    if (!countryCode) {
      return ApiOk<ShippingMethod[]>([])
    }

    const params = new URLSearchParams({ countryCode })

    return await makeRequest<ShippingMethod[]>(
      `api/v1/shipping/methods?${params}`,
    )
  },
}
export default shippingApi
