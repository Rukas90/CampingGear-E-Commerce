import { ContentContainer, Feed, Footer, Newsletter, TopNav } from "@components"
import { Outlet } from "react-router-dom"

const Page = () => {
  return (
    <div className="w-full h-full min-h-svh flex flex-col">
      <main className="flex-1 flex flex-col">
        <div className="flex flex-col flex-1">
          <TopNav />
          <ContentContainer>
            <Feed />
            <div className="flex flex-col flex-1">
              <Outlet />
            </div>
          </ContentContainer>
        </div>
      </main>
      <Newsletter />
      <Footer />
    </div>
  )
}
export default Page
