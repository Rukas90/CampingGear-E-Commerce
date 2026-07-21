import { createContext } from "react"

export interface AuthData {}

const AuthContext = createContext<AuthData | undefined>(undefined)

const AuthProvider = ({ children }: React.PropsWithChildren) => {
  return <AuthContext.Provider value={{}}>{children}</AuthContext.Provider>
}
