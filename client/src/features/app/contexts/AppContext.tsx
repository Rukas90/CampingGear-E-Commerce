import { createContext, useContext, useEffect, useState } from "react"
import { useLocation } from "react-router-dom"

type Menu = {
  open: () => void
  close: () => void
  isOpened: boolean
}
interface AppData {
  menu: Menu
}

const AppContext = createContext<AppData | undefined>(undefined)

const AppProvider = ({ children }: React.PropsWithChildren) => {
  const [isMenuOpened, setOpenedMenu] = useState(false)
  const { pathname } = useLocation()

  useEffect(() => closeMenu(), [pathname])

  const openMenu = () => {
    setOpenedMenu(true)
  }

  const closeMenu = () => {
    setOpenedMenu(false)
  }

  return (
    <AppContext.Provider
      value={{
        menu: {
          open: openMenu,
          close: closeMenu,
          isOpened: isMenuOpened,
        },
      }}
    >
      {children}
    </AppContext.Provider>
  )
}
export default AppProvider

export const useApp = () => {
  const context = useContext(AppContext)

  if (!context) {
    throw new Error("useApp can only be used within the AppProvider.")
  }
  return context
}
