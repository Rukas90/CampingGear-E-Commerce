import { IconArrow, IconMenu } from "@components"
import NavMenuItem from "./NavMenuItem"
import clsx from "clsx"

interface NavMenuProps {
  openListing?: () => void
  showingListing?: boolean
}

const NavMenu = ({ openListing, showingListing }: NavMenuProps) => {
  return (
    <div className="flex items-center">
      <ul className="lg:flex hidden gap-5 dark:text-stone-200">
        <NavMenuItem
          className="flex gap-1.5 items-center"
          onMouseOver={openListing}
        >
          Products{" "}
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
      <IconMenu className="lg:hidden block size-7" />
    </div>
  )
}
export default NavMenu
