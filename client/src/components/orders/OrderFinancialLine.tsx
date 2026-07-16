import { formatPrice } from "@utils"
import { twMerge } from "tailwind-merge"

interface OrderFinancialLineProps {
  label?: string
  price?: number
  className?: string
}

const OrderFinancialLine = ({
  label,
  price,
  className,
}: OrderFinancialLineProps) => (
  <div
    className={twMerge(
      "flex justify-between items-center py-2.5 border-b border-b-neutral-200 text-sm text-neutral-800",
      className,
    )}
  >
    <p className="text-sm text-neutral-800">{label}</p>
    <p>{formatPrice(price)}</p>
  </div>
)

export default OrderFinancialLine
