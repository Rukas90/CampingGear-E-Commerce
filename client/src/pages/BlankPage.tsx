import {
  CartSidePanel,
  FooterBottom,
  Line,
  MobileSideMenu,
  TopNav,
} from "@features"
import { Outlet } from "react-router-dom"

interface BlankPageProps {
  menu?: boolean
  cart?: boolean
}
const BlankPage = ({ menu, cart }: BlankPageProps) => {
  return (
    <div className="relative flex flex-col w-full min-h-dvh">
      <TopNav className="relative" showMenuItems={menu} showCartButton={cart} />
      <MobileSideMenu />
      <Line className="bg-neutral-200" />
      <div className="flex  flex-1">
        <Outlet />
      </div>
      <FooterBottom />
      <CartSidePanel />
    </div>
  )
}
export default BlankPage
