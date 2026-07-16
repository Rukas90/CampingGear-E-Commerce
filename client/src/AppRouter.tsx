import { lazy } from "react"
import { Route, Routes } from "react-router-dom"
import ContentPage from "./pages/ContentPage"
import BlankPage from "./pages/BlankPage"
import { GuestOnlyGuard, ProtectedGuard, useAuthInterceptor } from "@features"
import AccountPage from "./pages/AccountPage"

const HomePage = lazy(() => import("./pages/HomePage"))
const ProductsPage = lazy(() => import("./pages/ProductsPage"))
const ProductPage = lazy(() => import("./pages/ProductPage"))
const LoginPage = lazy(() => import("./pages/LoginPage"))
const RegisterPage = lazy(() => import("./pages/RegisterPage"))
const CartPage = lazy(() => import("./pages/CartPage"))
const CheckoutPage = lazy(() => import("./pages/CheckoutPage"))
const PaymentPage = lazy(() => import("./pages/PaymentPage"))
const NotFoundPage = lazy(() => import("./pages/NotFoundPage"))
const OrderConfirmationPage = lazy(
  () => import("./pages/OrderConfirmationPage"),
)
const OrderCancelledPage = lazy(() => import("./pages/OrderCancelledPage"))
const ProfilePage = lazy(() => import("./pages/ProfilePage"))
const OrdersPage = lazy(() => import("./pages/OrdersPage"))
const AddressesPage = lazy(() => import("./pages/AddressesPage"))
const OrderPage = lazy(() => import("./pages/OrderPage"))
const WishlistPage = lazy(() => import("./pages/WishlistPage"))

const AppRouter = () => {
  useAuthInterceptor()

  return (
    <Routes>
      <Route element={<ContentPage />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/products/:category" element={<ProductsPage />} />
        <Route path="/product/:slug" element={<ProductPage />} />
        <Route element={<GuestOnlyGuard />}>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
        </Route>
        <Route path="/cart" element={<CartPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Route>
      <Route element={<ProtectedGuard />}>
        <Route element={<BlankPage />}>
          <Route element={<AccountPage />}>
            <Route path="/profile" element={<ProfilePage />} />
            <Route path="/orders" element={<OrdersPage />} />
            <Route path="/addresses" element={<AddressesPage />} />
          </Route>
          <Route path="/order/:orderId" element={<OrderPage />} />
          <Route path="/wishlist" element={<WishlistPage />} />
        </Route>
      </Route>
      <Route element={<BlankPage menu={false} />}>
        <Route path="/checkout" element={<CheckoutPage />} />
      </Route>
      <Route element={<BlankPage menu={false} cart={false} />}>
        <Route path="/orders/pay/:orderId" element={<PaymentPage />} />
        <Route
          path="/orders/confirmation/:orderId"
          element={<OrderConfirmationPage />}
        />
        <Route
          path="/orders/failed/:orderId"
          element={<OrderCancelledPage />}
        />
      </Route>
    </Routes>
  )
}
export default AppRouter
