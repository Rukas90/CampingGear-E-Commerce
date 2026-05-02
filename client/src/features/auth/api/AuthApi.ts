import { makeRequest } from "@lib"
import type { LoginData, RegisterData } from "../schemas"
import type { CustomerAccount } from "@types"

const authApi = {
  login: async (data: LoginData) =>
    await makeRequest<CustomerAccount>("/api/v1/auth/login", "post", data),

  register: async (data: RegisterData) =>
    await makeRequest<CustomerAccount>("/api/v1/auth/register", "post", data),

  refresh: async () =>
    await makeRequest<CustomerAccount>("/api/v1/auth/refresh", "post"),

  me: async () =>
    await makeRequest<CustomerAccount | null>("/api/v1/me", "get"),
}
export default authApi
