import { ContentContainer, Feed, Footer, TopNav } from "@components"
import { Outlet } from "react-router-dom"

const Page = () => {
  return (
    <div className="w-full h-full min-h-svh flex flex-col">
      <TopNav />
      <ContentContainer>
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
