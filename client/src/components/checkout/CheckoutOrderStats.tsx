import { CostLabel } from "@components"
import { useCheckoutStats, useSessionSummary } from "@features"

const CheckoutOrderStats = () => {
  const { summary } = useSessionSummary()
  const { stats, isPending } = useCheckoutStats()

  if (!stats) {
    return
  }

  return (
    <div className="flex flex-col gap-1.5 mt-6">
      <p className="flex justify-between text-xm">
        <span>Subtotal · {summary.cartCount} items</span>
        <CostLabel
          className="font-normal"
          cost={stats.subtotal}
          isLoading={isPending}
        />
      </p>
      <p className="flex justify-between text-xm">
        <span>Tax</span>
        <CostLabel
          className="text-neutral-700 font-normal"
          cost={stats.tax}
          noCostLabel="Enter shipping address"
          isLoading={isPending}
        />
      </p>
      <p className="flex justify-between text-xm">
        <span>Shipping</span>
        <CostLabel
          className="text-neutral-700 font-normal"
          cost={stats.shippingCost}
          noCostLabel="Enter shipping address"
          isLoading={isPending}
        />
      </p>
      <div className="flex justify-between text-lg mt-4 font-medium">
        <span>Total</span>
        <div className="flex items-center gap-1.5">
          <span className="text-xm font-light text-neutral-600 mr-0.5 tracking-normal">
            EUR
          </span>{" "}
          <CostLabel
            cost={stats.total ?? stats.subtotal}
            isLoading={isPending}
          />
        </div>
      </div>
    </div>
  )
}
export default CheckoutOrderStats
