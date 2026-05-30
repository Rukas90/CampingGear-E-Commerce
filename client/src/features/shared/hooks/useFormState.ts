import { useState } from "react"

export const useFormState = <TData>(baseline: TData) => {
  const [touched, setTouched] = useState<Set<string>>(new Set())
  const [dirtyKeys, setDirtyKeys] = useState<Set<string>>(new Set())

  const toKey = (fieldKey: string, key?: string): string =>
    key !== undefined ? `${fieldKey}.${key}` : fieldKey

  const markTouched = (key: string) =>
    setTouched((prev) => new Set(prev).add(key))

  const markDirty = (
    key: string,
    currentVal: unknown,
    baselineVal: unknown,
  ) => {
    const dirty = JSON.stringify(currentVal) !== JSON.stringify(baselineVal)
    setDirtyKeys((prev) => {
      const next = new Set(prev)
      dirty ? next.add(key) : next.delete(key)
      return next
    })
  }

  const markKeyTouched = (fieldKey: string, key?: string) =>
    markTouched(toKey(fieldKey, key))

  const markKeyDirty = (fieldKey: keyof TData, key: string, val: unknown) => {
    const baselineField = baseline[fieldKey]
    const baselineVal =
      baselineField && typeof baselineField === "object"
        ? (baselineField as any)[key]
        : undefined
    markDirty(toKey(String(fieldKey), key), val, baselineVal)
  }

  const markRootDirty = (key: keyof TData, val: unknown) =>
    markDirty(String(key), val, baseline[key])

  const isTouched = (key: string) => touched.has(key)
  const isDirty = (key: string) => dirtyKeys.has(key)
  const isAnyDirty = () => dirtyKeys.size > 0

  const reset = (keys?: string[]) => {
    if (keys) {
      setTouched((prev) => {
        const next = new Set(prev)
        keys.forEach((k) => next.delete(k))
        return next
      })
      setDirtyKeys((prev) => {
        const next = new Set(prev)
        keys.forEach((k) => next.delete(k))
        return next
      })
    } else {
      setTouched(new Set())
      setDirtyKeys(new Set())
    }
  }

  const resetDirty = () => {
    setDirtyKeys(new Set())
  }

  return {
    toKey,
    markTouched,
    markKeyTouched,
    markKeyDirty,
    markRootDirty,
    isTouched,
    isDirty,
    isAnyDirty,
    reset,
    resetDirty,
  }
}
