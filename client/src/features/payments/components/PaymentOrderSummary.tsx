import { Line } from "@features"
import { formatPrice } from "@utils"
import type { OrderDetails } from "@types"
import PaymentCostLabel from "./PaymentCostLabel"

interface PaymentOrderSummaryProps {
  order: OrderDetails
}

const PaymentOrderSummary = ({ order }: PaymentOrderSummaryProps) => {
  return (
    <div>
      <div className="mb-6">
        <p className="text-4xl font-bold text-center mb-2">
          {formatPrice(order.financials.total)}
        </p>
        <p className="text-xs text-neutral-400 text-center">
          Order #{order.token}
        </p>
      </div>
      <div className="mx-auto min-w-md max-w-full p-6 border-neutral-200 border rounded-lg bg-stone-100">
        <p className="text-base font-semibold mb-3">Order summary</p>
        <p>Line items ...</p>
        <Line className="my-3" />
        <div className="flex flex-col gap-1.5">
          <PaymentCostLabel
            label="Subtotal"
            price={order.financials.subtotal}
          />
          <PaymentCostLabel label="Tax" price={order.financials.tax} />
          <PaymentCostLabel
            label={`Shipping - ${order.shippingName}`}
            price={order.financials.shippingCost}
          />
        </div>
        <Line className="my-3" />
        <p className="flex justify-between text-sm">
          <span className="font-medium">Total</span>
          <span className="font-medium">
            {formatPrice(order.financials.total)}
          </span>
        </p>
      </div>
    </div>
  )
}

export default PaymentOrderSummary
