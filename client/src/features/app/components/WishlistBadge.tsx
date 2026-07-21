import CountBadge from "./CountBadge"
import { useWishlist, IconSaved } from "@features"
import { Link } from "react-router-dom"

const WishlistBadge = () => {
  const { items } = useWishlist()
  return (
    <Link to="/wishlist">
      <CountBadge icon={IconSaved} count={items?.length ?? 0} />
    </Link>
  )
}
export default WishlistBadge
