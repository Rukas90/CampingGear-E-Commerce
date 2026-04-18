import { lazy } from "react"
import { Route, Routes } from "react-router-dom"
import Page from "./pages/Page"

const HomePage = lazy(() => import("./pages/HomePage"))
const ProductsPage = lazy(() => import("./pages/ProductsPage"))
const NotFoundPage = lazy(() => import("./pages/NotFoundPage"))

const AppRouter = () => {
  return (
    <Routes>
      <Route element={<Page />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/products" element={<ProductsPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Route>
    </Routes>
  )
}
export default AppRouter
