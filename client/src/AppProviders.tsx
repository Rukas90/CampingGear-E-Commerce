import { BrowserRouter } from "react-router-dom"
import {
  AppProvider,
  AuthProvider,
  CartProvider,
  WishlistProvider,
} from "@features"
import "react-loading-skeleton/dist/skeleton.css"

const AppProviders = ({ children }: React.PropsWithChildren) => {
  return (
    <AuthProvider>
      <CartProvider>
        <WishlistProvider>
          <BrowserRouter>
            <AppProvider>{children}</AppProvider>
          </BrowserRouter>
        </WishlistProvider>
      </CartProvider>
    </AuthProvider>
  )
}
export default AppProviders
