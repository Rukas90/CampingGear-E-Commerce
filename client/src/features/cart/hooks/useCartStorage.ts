import { useStorage } from "@features"
import type { CartItem, SkuCode } from "@types"

const KEY = "guest_cart"

const useCartStorage = () => {
  const { items, dispatch } = useStorage<CartItem>(KEY)

  const addItemToStorage = (item: CartItem) => {
    const existing = items.find((i) => i.code === item.code)

    if (existing) {
      dispatch({
        type: "UPDATE",
        predicate: (i) => i.code === item.code,
        updater: (i) => ({ ...i, quantity: i.quantity + item.quantity }),
      })
    } else {
      dispatch({ type: "ADD", payload: item })
    }
  }

  const updateStorageItemQuantity = (code: SkuCode, quantity: number) =>
    dispatch({
      type: "UPDATE",
      predicate: (i) => i.code === code,
      updater: (i) => ({ ...i, quantity }),
    })

  const removeItemFromStorage = (code: SkuCode) =>
    dispatch({ type: "REMOVE", predicate: (i) => i.code !== code })

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
