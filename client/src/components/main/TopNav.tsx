import {
  LogoWithText,
  PageWrapper,
  ProductCategoryListing,
  WishlistBadge,
  CartBadge,
} from "@components"
import { Link, useLocation } from "react-router-dom"
import { useEffect, useState } from "react"
import clsx from "clsx"
import { useCartContext } from "@features"
import { twMerge } from "tailwind-merge"
import AccountBadge from "./AccountBadge"
import NavMenu from "./NavMenu"

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
          <div className="grid grid-cols-3">
            {showMenuItems && (
              <NavMenu
                openListing={() => setShowListing(true)}
                showingListing={showListing}
              />
            )}
            <div className="flex items-center justify-center">
              <Link to="/">
                <LogoWithText />
              </Link>
            </div>
            <div className="flex gap-5 justify-end items-center">
              {showMenuItems && (
                <div className="sm:flex hidden gap-5 items-center">
                  <AccountBadge />
                  <WishlistBadge />
                </div>
              )}
              {showCartButton && <CartBadge onClicked={openCartPanel} />}
            </div>
          </div>
        </PageWrapper>
        <div
          className={clsx(
            "absolute w-full left-0 bg-white translate-y-2 z-63 transition-all duration-200",
            showListing && "top-full opacity-100 pointer-events-auto",
            !showListing && "-top-full opacity-0 pointer-events-none",
          )}
        >
          <div className="w-full bg-neutral-200 h-0.5" />
          <PageWrapper className="py-4">
            <ProductCategoryListing />
          </PageWrapper>
          <div className="w-full bg-black h-0.5" />
        </div>
      </div>
    </nav>
  )
}
export default TopNav

// <IconSearch className="size-5 dark:text-stone-100 text-stone-800 z-1 relative " />
