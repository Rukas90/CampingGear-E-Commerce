import { createContext, useContext } from "react"
import useAuthRefresh, { type AuthRefreshData } from "../hooks/useAuthRefresh"
import { useAuthInterceptor } from "../hooks"
import type { ProblemDetails } from "@types"

export interface AuthData {
  refresh: AuthRefreshData
}

const AuthContext = createContext<AuthData | undefined>(undefined)

export interface AuthChangeProps<TResult> {
  onBefore?: () => Promise<void>
  onSuccess?: (result: TResult) => Promise<void>
  onError?: (details: ProblemDetails) => void
}

const AuthProvider = ({ children }: React.PropsWithChildren) => {
  const refresh = useAuthRefresh()
  useAuthInterceptor({ refresh })

  return (
    <AuthContext.Provider value={{ refresh }}>{children}</AuthContext.Provider>
  )
}

export default AuthProvider

export const useAuth = () => {
  const context = useContext(AuthContext)

  if (!context) {
    throw new Error("useAuth must be used within AuthProvider")
  }
  return context
}
