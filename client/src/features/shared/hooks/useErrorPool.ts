import type { ProblemDetailsError } from "@types"
import { useState } from "react"

export interface ErrorPool {
  setErrors: (errors: ProblemDetailsError[]) => void
  getError: (key: string) => string | undefined
  clearError: (key: string) => void
  clear: () => void
  pool: Record<string, string>
}

const useErrorPool = (): ErrorPool => {
  const [pool, setPool] = useState<Record<string, string>>({})

  const setErrors = (errors: ProblemDetailsError[]) => {
    const map = errors.reduce(
      (acc, e) => {
        acc[getKey(e.name)] = e.reason
        return acc
      },
      {} as Record<string, string>,
    )
    setPool((prev) => ({ ...prev, ...map }))
  }

  const getError = (key: string): string | undefined => pool[getKey(key)]

  const clearError = (key: string) => {
    setPool((prev) => {
      const next = { ...prev }
      delete next[getKey(key)]
      return next
    })
  }

  const clear = () => setPool({})

  const getKey = (key: string) => key.toLocaleLowerCase()

  return { setErrors, getError, clearError, clear, pool }
}
export default useErrorPool
