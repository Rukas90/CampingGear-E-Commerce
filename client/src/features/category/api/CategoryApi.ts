import { makeRequest } from "@lib"
import type { Category, CategoryGroup } from "@types"

const categoryApi = {
  getTopCategories: async (count: number) =>
    await makeRequest<Category[]>(`api/v1/categories/top?count=${count}`),

  getAllCategories: async () =>
    await makeRequest<Category[]>("api/v1/categories"),

  getAllCategoryGroups: async () =>
    await makeRequest<CategoryGroup[]>("api/v1/category/groups"),
}
export default categoryApi
