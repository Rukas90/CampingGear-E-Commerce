import { makeRequest } from "@lib"
import type { SessionSummary } from "@types"

const sessionApi = {
  getSessionSummary: async () =>
    await makeRequest<SessionSummary>("/api/v1/session/summary"),
}
export default sessionApi
