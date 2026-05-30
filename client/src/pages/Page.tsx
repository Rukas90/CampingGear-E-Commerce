import {
  CartSidePanel,
  ContentContainer,
  Feed,
  Footer,
  TopNav,
} from "@components"
import { useCart } from "@features"
import { Outlet } from "react-router-dom"

const Page = () => {
  const {} = useCart()

  return (
    <div className="relative w-full h-full min-h-svh flex flex-col">
      <TopNav />
      <ContentContainer>
        <div className="bg-neutral-200 py-2 px-4 text-center hidden">
          <p className="font-semibold">Disclaimer</p>
          <p className="text-sm text-neutral-600">
            This is a portfolio project and not a real site. I do not sell any
            of the products and all of it is just for showcase.
            <br />
            If you are the owner of any of the products and would like me to
            take them down, please let me know by emailing me at{" "}
            <span className="font-medium">rukas.skirkevicius@gmail.com</span>
          </p>
        </div>
        <Feed />
      </ContentContainer>
      <main className="relative flex flex-col flex-1">
        <div className="flex flex-col flex-1">
          <Outlet />
        </div>
      </main>
      <Footer />
      <CartSidePanel />
    </div>
  )
}
export default Page
