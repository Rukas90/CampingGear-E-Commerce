import { CartSidePanel, FooterBottom, Line, TopNav } from "@components"
import type { TopNavVariant } from "@types"
import { Outlet } from "react-router-dom"

interface BlankPageProps {
  topNavigation?: TopNavVariant
}
const BlankPage = ({ topNavigation = "functionless" }: BlankPageProps) => {
  return (
    <div className="flex flex-col w-full min-h-dvh">
      <TopNav className="relative" variant={topNavigation} />
      <Line className="bg-neutral-200" />
      <div className="flex lg:flex-row flex-col-reverse flex-1">
        <Outlet />
      </div>
      <FooterBottom />
      <CartSidePanel />
    </div>
  )
}
export default BlankPage
