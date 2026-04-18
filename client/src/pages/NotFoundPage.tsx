import { Button } from "@components"
import { Link } from "react-router-dom"

const NotFoundPage = () => {
  return (
    <div className="w-full h-full pt-12 px-24 flex justify-center flex-col items-center gap-4 flex-1 text-center">
      <p className="text-6xl font-bold">404 Page Not Found</p>
      <p className="text-lg">The page you requested does not exist.</p>
      <Link to="/">
        <Button style="contrast">Continue shopping</Button>
      </Link>
    </div>
  )
}
export default NotFoundPage
