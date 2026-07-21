import { useServerHealth } from "@features"
import AppProviders from "./AppProviders"
import AppRouter from "./AppRouter"
import AppStartingPage from "./pages/AppStartingPage"

const App = () => {
  const { isSuccess } = useServerHealth()

  if (!isSuccess) {
    return <AppStartingPage />
  }

  return (
    <AppProviders>
      <AppRouter />
    </AppProviders>
  )
}
export default App
