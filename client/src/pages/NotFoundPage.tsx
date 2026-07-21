import { ContrastButton } from "@features"
import { Link } from "react-router-dom"

const NotFoundPage = () => {
  return (
    <>
      <title>Trailstore - Not Found</title>
      <div className="w-full h-full px-24 flex justify-center flex-col items-center gap-4 text-center">
        <p className="text-5xl font-bold">404 Page Not Found</p>
        <p>The page you requested does not exist.</p>
        <Link to="/">
          <ContrastButton className="text-sm px-2.5">
            Continue shopping
          </ContrastButton>
        </Link>
      </div>
    </>
  )
}
export default NotFoundPage
