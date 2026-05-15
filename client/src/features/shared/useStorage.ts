import { useReducer } from "react"
import { LocalStorage } from "./Storage"

type Predicate<T> = (item: T) => boolean
type Updater<T> = (item: T) => T

type Action<T> =
  | { type: "SET"; payload: T[] }
  | { type: "ADD"; payload: T }
  | { type: "REMOVE"; predicate: Predicate<T> }
  | { type: "UPDATE"; predicate: Predicate<T>; updater: Updater<T> }
  | { type: "CLEAR" }

const createReducer =
  <T>() =>
  (state: T[], action: Action<T>): T[] => {
    switch (action.type) {
      case "SET":
        return action.payload
      case "ADD":
        return [...state, action.payload]
      case "REMOVE":
        return state.filter((i) => !action.predicate(i))
      case "UPDATE":
        return state.map((i) => (action.predicate(i) ? action.updater(i) : i))
      case "CLEAR":
        return []
      default:
        return state
    }
  }

const useStorage = <T>(key: string) => {
  const [items, dispatch] = useReducer(createReducer<T>(), undefined, () =>
    LocalStorage.getItems<T>(key),
  )

  const handleDispatch = (action: Action<T>) => {
    dispatch(action)

    LocalStorage.setItems(key, createReducer<T>()(items, action))
  }

  return { items, dispatch: handleDispatch }
}
export default useStorage
