import { BrowserRouter } from "react-router-dom"

const AppProviders = ({ children }: React.PropsWithChildren) => {
  return <BrowserRouter>{children}</BrowserRouter>
}
export default AppProviders
