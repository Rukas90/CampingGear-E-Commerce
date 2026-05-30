import { IconButton, IconCart } from "@components"
import CountBadge from "../main/CountBadge"
import { useSessionSummary } from "@features"

interface CartBadgeProps {
  onClicked?: () => void
}
const CartBadge = ({ onClicked }: CartBadgeProps) => {
  const { summary } = useSessionSummary()

  return (
    <IconButton
      onClick={onClicked}
      icon={<CountBadge icon={IconCart} count={summary.cartCount} />}
    />
  )
}
export default CartBadge
