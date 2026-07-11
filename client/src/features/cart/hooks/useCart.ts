import { useQueryHandler, type QueryOptions } from "@features"
import cartApi from "../api/cartApi"

const useCart = (options?: QueryOptions) => {
  const query = useQueryHandler({
    key: ["cart"],
    func: () => cartApi.getCart(),
    ...options,
  })

  return { items: query.data, ...query }
}
export default useCart
