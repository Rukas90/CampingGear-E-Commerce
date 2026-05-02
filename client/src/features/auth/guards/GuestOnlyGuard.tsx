import { useAccount } from "@features"
import { Navigate, Outlet } from "react-router-dom"

const GuestOnlyGuard = ({ children }: React.PropsWithChildren) => {
  const { account } = useAccount()

  if (account) {
    return <Navigate to="/" replace />
  }
  return children ? <>{children}</> : <Outlet />
}
export default GuestOnlyGuard
