import { useState } from "react"

export const useFormErrors = () => {
  const [errors, setErrors] = useState<Record<string, string>>({})

  const errorKey = (key: string | number | symbol): string =>
    String(key).toLowerCase()

  const getError = (key: string | number | symbol): string | undefined =>
    errors[errorKey(key)]

  const getNestedError = (
    fieldKey: string | number | symbol,
    key: string | number | symbol,
  ): string | undefined =>
    errors[errorKey(`${String(fieldKey)}.${String(key)}`)] ??
    errors[errorKey(key)]

  const setFromProblemDetails = (
    errors: Array<{ name: string; reason: string }>,
  ) => {
    setErrors(
      Object.fromEntries(errors.map((err) => [errorKey(err.name), err.reason])),
    )
  }

  const clear = () => setErrors({})

  const clearError = (key: string) =>
    setErrors((prev) => {
      const next = { ...prev }
      delete next[errorKey(key)]
      return next
    })

  return {
    getError,
    getNestedError,
    setFromProblemDetails,
    clear,
    clearError,
    errorKey,
  }
}
