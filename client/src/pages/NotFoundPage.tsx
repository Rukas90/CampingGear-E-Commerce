import { Button } from "@components"
import { Link } from "react-router-dom"

const NotFoundPage = () => {
  return (
    <>
      <div className="w-full h-full px-24 flex justify-center flex-col items-center gap-4 text-center">
        <p className="text-5xl font-bold">404 Page Not Found</p>
        <p>The page you requested does not exist.</p>
        <Link to="/">
          <Button className="text-sm" style="contrast">
            Continue shopping
          </Button>
        </Link>
      </div>
    </>
  )
}
export default NotFoundPage
