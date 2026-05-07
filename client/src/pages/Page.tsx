import { ContentContainer, Feed, Footer, TopNav } from "@components"
import { Outlet } from "react-router-dom"

const Page = () => {
  return (
    <div className="w-full h-full min-h-svh flex flex-col">
      <TopNav />
      <ContentContainer>
        <div className="bg-neutral-200 py-2 px-4 text-center">
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
      <main className="flex flex-col my-auto">
        <div className="flex flex-col h-full">
          <Outlet />
        </div>
      </main>
      <Footer />
    </div>
  )
}
export default Page
