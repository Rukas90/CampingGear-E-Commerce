import { makeRequest } from "@lib"
import type { Country } from "@types"

const countriesApi = {
  getCountries: async () => await makeRequest<Country[]>(`api/v1/countries`),
}
export default countriesApi
