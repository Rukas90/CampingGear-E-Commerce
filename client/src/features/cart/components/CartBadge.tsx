import { IconButton, IconCart, CountBadge } from "@features"
import { useCartSummary } from "@features"

interface CartBadgeProps {
  onClicked?: () => void
}
const CartBadge = ({ onClicked }: CartBadgeProps) => {
  const { summary } = useCartSummary()

  return (
    <IconButton
      onClick={onClicked}
      icon={<CountBadge icon={IconCart} count={summary?.count ?? 0} />}
    />
  )
}
export default CartBadge
