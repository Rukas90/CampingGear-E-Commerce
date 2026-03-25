import { lazy } from "react"
import { Route, Routes } from "react-router-dom"

const HomePage = lazy(() => import("./pages/HomePage"))

const AppRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
    </Routes>
  )
}
export default AppRouter
