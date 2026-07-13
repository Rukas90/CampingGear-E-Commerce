import { useAccount } from "@features"
import { Navigate, Outlet } from "react-router-dom"

const ProtectedGuard = ({ children }: React.PropsWithChildren) => {
  const { account, isLoggedIn } = useAccount()

  if (account === undefined) {
    return
  }
  if (!isLoggedIn) {
    return <Navigate to="/" replace />
  }
  return children ? <>{children}</> : <Outlet />
}
export default ProtectedGuard
