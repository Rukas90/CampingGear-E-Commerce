import { lazy } from "react"
import { Route, Routes } from "react-router-dom"
import ContentPage from "./pages/ContentPage"
import BlankPage from "./pages/BlankPage"
import { GuestOnlyGuard, useAuthInterceptor } from "@features"
import OrderConfirmationPage from "./pages/OrderConfirmationPage"
import OrderCanceledPage from "./pages/OrderCanceledPage"

const HomePage = lazy(() => import("./pages/HomePage"))
const ProductsPage = lazy(() => import("./pages/ProductsPage"))
const ProductPage = lazy(() => import("./pages/ProductPage"))
const LoginPage = lazy(() => import("./pages/LoginPage"))
const RegisterPage = lazy(() => import("./pages/RegisterPage"))
const CartPage = lazy(() => import("./pages/CartPage"))
const CheckoutPage = lazy(() => import("./pages/CheckoutPage"))
const PaymentPage = lazy(() => import("./pages/PaymentPage"))
const NotFoundPage = lazy(() => import("./pages/NotFoundPage"))

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
      <Route element={<BlankPage topNavigation="checkout" />}>
        <Route path="/checkout" element={<CheckoutPage />} />
      </Route>
      <Route element={<BlankPage topNavigation="functionless" />}>
        <Route path="/orders/pay/:orderId" element={<PaymentPage />} />
        <Route
          path="/orders/confirmation/:orderId"
          element={<OrderConfirmationPage />}
        />
        <Route path="/orders/failed/:orderId" element={<OrderCanceledPage />} />
      </Route>
    </Routes>
  )
}
export default AppRouter
