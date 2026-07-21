import NavMenuItem from "./NavMenuItem"
import clsx from "clsx"
import { IconArrow, IconButton, IconMenu, IconX, useApp } from "@features"

interface NavMenuProps {
  openListing?: () => void
  showingListing?: boolean
}
const NavMenu = ({ openListing, showingListing }: NavMenuProps) => {
  const { menu } = useApp()

  return (
    <div className="flex items-center flex-1">
      <ul className="lg:flex hidden gap-5 dark:text-stone-200">
        <NavMenuItem
          className="flex gap-1.5 items-center"
          onMouseOver={openListing}
        >
          Products
          <IconArrow
            className={clsx(
              "size-3 transition-transform will-change-transform",
              showingListing ? "rotate-90" : "rotate-270",
            )}
          />
        </NavMenuItem>
        <NavMenuItem>Help</NavMenuItem>
        <NavMenuItem>About</NavMenuItem>
      </ul>
      <div className="lg:hidden flex size-10">
        {menu.isOpened ? (
          <IconButton
            className="mx-auto"
            onClick={menu.close}
            icon={<IconX className="size-4" strokeWidth={2.5} />}
          />
        ) : (
          <IconButton
            className="mx-auto"
            onClick={menu.open}
            icon={<IconMenu className="size-7" />}
          />
        )}
      </div>
    </div>
  )
}
export default NavMenu
