import {
  IconAccount,
  IconArrow,
  IconSearch,
  InputField,
  LogoWithText,
  PageWrapper,
  WishlistBadge,
} from "@components"
import CartBadge from "./CartBadge"
import { Link } from "react-router-dom"
import { TopCategories } from "@components/categories"

const TopNav = () => {
  return (
    <nav className="fixed dark:bg-stone-950 bg-white w-full py-4 h-18 z-64">
      <div className="relative">
        <PageWrapper>
          <div className="flex items-center justify-between w-full">
            <ul className="flex gap-5 w-1/3 dark:text-stone-200">
              <li className="font-normal flex gap-1.5 items-center">
                Products <IconArrow className="rotate-90 size-4" />
              </li>
              <li className="font-normal">Help</li>
              <li className="font-normal">About</li>
            </ul>
            <div className="flex items-center justify-center w-1/3">
              <Link to="/">
                <LogoWithText />
              </Link>
            </div>
            <div className="flex gap-5 items-center justify-end w-1/3">
              <div className="relative size-5">
                <IconSearch className="size-full dark:text-stone-100 text-stone-800 z-1 relative " />
                <InputField
                  className="rounded-xl absolute right-full translate-x-7.5 top-1/2 -translate-y-1/2"
                  placeholder="Search ..."
                />
              </div>
              <IconAccount className="size-5 dark:text-stone-100 text-stone-800" />
              <WishlistBadge />
              <CartBadge />
            </div>
          </div>
        </PageWrapper>
        <div className="absolute w-full top-full left-0 bg-white translate-y-2 z-128">
          <div className="w-full bg-neutral-300 h-px" />
          <PageWrapper className="py-8">
            <TopCategories />
          </PageWrapper>
        </div>
      </div>
    </nav>
  )
}
export default TopNav
