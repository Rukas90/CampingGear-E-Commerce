import {
  IconAccount,
  IconArrow,
  IconSearch,
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
import type { TopNavVariant } from "@types"

interface TopNavProps extends Omit<
  React.ComponentProps<"nav">,
  "children" | "onMouseLeave"
> {
  variant?: TopNavVariant
}
const TopNav = ({ variant = "default", className, ...props }: TopNavProps) => {
  const { openCartPanel } = useCartContext()
  const [showListing, setShowListing] = useState(false)
  const location = useLocation()

  useEffect(() => setShowListing(false), [location.pathname])

  const hasMenuItems = variant === "default"
  const hasCart = variant !== "functionless"

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
        <PageWrapper className="z-65 bg-white">
          <div className="flex items-center justify-between w-full">
            <div className="w-1/3">
              {hasMenuItems && (
                <ul className="flex gap-5 dark:text-stone-200">
                  <li
                    className="font-normal text-sm flex gap-1.5 items-center"
                    onMouseOver={() => setShowListing(true)}
                  >
                    Products <IconArrow className="rotate-90 size-3" />
                  </li>
                  <li className="font-normal text-sm">Help</li>
                  <li className="font-normal text-sm">About</li>
                </ul>
              )}
            </div>
            <div className="flex items-center justify-center w-1/3">
              <Link to="/">
                <LogoWithText />
              </Link>
            </div>
            <div className="flex gap-5 items-center justify-end w-1/3">
              {hasMenuItems && (
                <>
                  <IconSearch className="size-5 dark:text-stone-100 text-stone-800 z-1 relative " />
                  <IconAccount className="size-5 dark:text-stone-100 text-stone-800" />
                  <WishlistBadge />
                </>
              )}
              {hasCart && <CartBadge onClicked={openCartPanel} />}
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
