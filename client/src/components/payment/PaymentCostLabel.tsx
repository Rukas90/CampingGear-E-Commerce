import { formatPrice } from "@utils"

interface PaymentCostLabelProps {
  label: string
  price: number
}
const PaymentCostLabel = ({ label, price }: PaymentCostLabelProps) => {
  return (
    <p className="flex justify-between text-xm text-neutral-600">
      <span>{label}</span>
      <span>{formatPrice(price)}</span>
    </p>
  )
}
export default PaymentCostLabel
