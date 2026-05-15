import { useQueryHandler, type QueryOptions } from "@features"
import cartApi from "../api/cartApi"

const useCartSkuQuery = (codes: string[], options?: QueryOptions) => {
  const query = useQueryHandler({
    key: ["cart-skus", codes],
    func: () => cartApi.getCartSkus({ codes }),
    options,
  })

  return { skus: query.data, ...query }
}
export default useCartSkuQuery
