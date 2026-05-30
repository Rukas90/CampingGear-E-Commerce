import { useStorage } from "@features"
import type { CartLineItem, SkuCode } from "@types"

const KEY = "guest_cart"

const useCartStorage = () => {
  const { items, dispatch } = useStorage<CartLineItem>(KEY)

  const compareCodes = (a: SkuCode, b: SkuCode) =>
    a.toLowerCase() === b.toLowerCase()

  const addItemToStorage = (item: CartLineItem) => {
    const existing = items.find((i) => compareCodes(i.code, item.code))

    if (existing) {
      dispatch({
        type: "UPDATE",
        predicate: (i) => compareCodes(i.code, item.code),
        updater: (i) => ({ ...i, quantity: i.quantity + item.quantity }),
      })
    } else {
      dispatch({ type: "ADD", payload: item })
    }
  }

  const updateStorageItemQuantity = (code: SkuCode, quantity: number) =>
    dispatch({
      type: "UPDATE",
      predicate: (i) => compareCodes(i.code, code),
      updater: (i) => ({ ...i, quantity }),
    })

  const removeItemFromStorage = (code: SkuCode) =>
    dispatch({ type: "REMOVE", predicate: (i) => compareCodes(i.code, code) })

  const clearItemFromStorage = () => dispatch({ type: "CLEAR" })

  return {
    items,
    addItemToStorage,
    updateStorageItemQuantity,
    removeItemFromStorage,
    clearItemFromStorage,
  }
}
export default useCartStorage
