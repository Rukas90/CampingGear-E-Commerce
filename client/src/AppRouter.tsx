import { lazy } from "react"
import { Route, Routes } from "react-router-dom"
import Page from "./pages/Page"
import { GuestOnlyGuard, useAuthInterceptor } from "@features"

const HomePage = lazy(() => import("./pages/HomePage"))
const ProductsPage = lazy(() => import("./pages/ProductsPage"))
const ProductPage = lazy(() => import("./pages/ProductPage"))
const LoginPage = lazy(() => import("./pages/LoginPage"))
const RegisterPage = lazy(() => import("./pages/RegisterPage"))
const NotFoundPage = lazy(() => import("./pages/NotFoundPage"))

const AppRouter = () => {
  useAuthInterceptor()

  return (
    <Routes>
      <Route element={<Page />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/products/:category" element={<ProductsPage />} />
        <Route path="/product/:slug" element={<ProductPage />} />
        <Route element={<GuestOnlyGuard />}>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />
        </Route>
        <Route path="*" element={<NotFoundPage />} />
      </Route>
    </Routes>
  )
}
export default AppRouter
