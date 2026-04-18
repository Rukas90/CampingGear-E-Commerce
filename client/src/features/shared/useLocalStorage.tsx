import { useState, useCallback } from "react"
import { storage } from "./Storage"

const useLocalStorage = <T,>(key: string, initial: T) => {
  const [value, setValue] = useState<T>(() => storage.get<T>(key) ?? initial)

  const set = useCallback(
    (next: T | ((prev: T) => T)) => {
      setValue((prev) => {
        const resolved =
          typeof next === "function" ? (next as (p: T) => T)(prev) : next
        storage.set(key, resolved)
        return resolved
      })
    },
    [key],
  )

  const remove = useCallback(() => {
    storage.remove(key)
    setValue(initial)
  }, [key, initial])

  return [value, set, remove] as const
}
export default useLocalStorage
