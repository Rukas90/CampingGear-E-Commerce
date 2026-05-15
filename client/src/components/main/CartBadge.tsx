import { IconCart } from "@components"
import CountBadge from "./CountBadge"
import { useCart } from "@features"

const CartBadge = () => {
  const { count } = useCart()

  return <CountBadge icon={IconCart} count={count} />
}
export default CartBadge
