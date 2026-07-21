import { makeRequest } from "@lib"

const appApi = {
  health: async () => await makeRequest<string>("/health", "get"),
}
export default appApi
