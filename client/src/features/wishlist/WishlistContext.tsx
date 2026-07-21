import { HandleReqFn } from "@lib"
import { useQuery, useQueryClient } from "@tanstack/react-query"
import type { ApiResult, SkuId, WishlistItem } from "@types"
import {
  createContext,
  useCallback,
  useContext,
  useMemo,
  useState,
} from "react"
import wishlistApi from "./wishlistApi"

interface WishlistData {
  toggleItem: (skuId: SkuId) => Promise<boolean>
  addItem: (skuId: SkuId) => Promise<boolean>
  removeItem: (skuId: SkuId) => Promise<boolean>
  isInWishlist: (skuId: SkuId) => boolean
  items: WishlistItem[] | undefined
  busy: boolean
}

const WishlistContext = createContext<WishlistData | undefined>(undefined)

const WishlistProvider = ({ children }: React.PropsWithChildren) => {
  const query = useQuery({
    queryKey: ["wishlist"],
    queryFn: () => HandleReqFn(() => wishlistApi.getAll()),
    retry: false,
  })
  const queryClient = useQueryClient()
  const [busy, setBusy] = useState(false)

  const items = query.data

  const process = useCallback(
    async <T,>(getPromise: () => Promise<ApiResult<T>>): Promise<boolean> => {
      if (busy) return false
      setBusy(true)
      try {
        const result = await getPromise()
        if (result.isSuccess) {
          await queryClient.invalidateQueries({ queryKey: ["wishlist"] })
          return true
        }
        return false
      } finally {
        setBusy(false)
      }
    },
    [busy, queryClient],
  )

  const isInWishlist = useCallback(
    (skuId: SkuId) => items?.some((item) => item.skuId === skuId) ?? false,
    [items],
  )

  const addItem = useCallback(
    (skuId: SkuId) => process(() => wishlistApi.add(skuId)),
    [process],
  )
  const removeItem = useCallback(
    (skuId: SkuId) => process(() => wishlistApi.remove(skuId)),
    [process],
  )
  const toggleItem = useCallback(
    (skuId: SkuId) => {
      if (!items) return Promise.resolve(false)
      return isInWishlist(skuId) ? removeItem(skuId) : addItem(skuId)
    },
    [items, isInWishlist, removeItem, addItem],
  )

  const value = useMemo(
    () => ({ toggleItem, addItem, removeItem, isInWishlist, items, busy }),
    [toggleItem, addItem, removeItem, items, busy],
  )

  return (
    <WishlistContext.Provider value={value}>
      {children}
    </WishlistContext.Provider>
  )
}
export default WishlistProvider

export const useWishlist = () => {
  const context = useContext(WishlistContext)

  if (!context) {
    throw new Error("useWishlist can only be used within the WishlistProvider.")
  }
  return context
}
