import {
  LogoWithText,
  PageWrapper,
  WishlistBadge,
  CartBadge,
  useCartContext,
} from "@features"
import AccountBadge from "./AccountBadge"
import NavMenu from "./NavMenu"
import ProductsMenu from "./ProductsMenu"
import { Link, useLocation } from "react-router-dom"
import { useEffect, useState } from "react"
import { twMerge } from "tailwind-merge"
import clsx from "clsx"

interface TopNavProps extends Omit<
  React.ComponentProps<"nav">,
  "children" | "onMouseLeave"
> {
  showMenuItems?: boolean
  showCartButton?: boolean
}
const TopNav = ({
  showMenuItems = true,
  showCartButton = true,
  className,
  ...props
}: TopNavProps) => {
  const { openCartPanel } = useCartContext()
  const [showListing, setShowListing] = useState(false)
  const location = useLocation()

  useEffect(() => setShowListing(false), [location.pathname])

  return (
    <nav
      className={twMerge(
        "fixed dark:bg-stone-950 bg-white w-full py-4 h-18 z-64",
        className,
      )}
      onMouseLeave={() => setShowListing(false)}
      {...props}
    >
      <div className="relative">
        <PageWrapper className="z-65">
          <div className="flex w-full">
            {showMenuItems && (
              <NavMenu
                openListing={() => setShowListing(true)}
                showingListing={showListing}
              />
            )}
            <div
              className={clsx(
                "flex items-center mx-auto flex-1",
                (showMenuItems || (!showMenuItems && !showCartButton)) &&
                  "justify-center",
              )}
            >
              <Link to="/">
                <LogoWithText />
              </Link>
            </div>
            {(showMenuItems || showCartButton) && (
              <div className="flex gap-5 justify-end items-center flex-1">
                {showMenuItems && (
                  <div className="sm:flex hidden gap-5 items-center">
                    <AccountBadge />
                    <WishlistBadge />
                  </div>
                )}
                {showCartButton && <CartBadge onClicked={openCartPanel} />}
              </div>
            )}
          </div>
        </PageWrapper>
        <ProductsMenu className="lg:block hidden" show={showListing} />
      </div>
    </nav>
  )
}
export default TopNav

// <IconSearch className="size-5 dark:text-stone-100 text-stone-800 z-1 relative " />
