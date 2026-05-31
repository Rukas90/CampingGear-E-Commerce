import { SkeletonLine } from "@components"
import { useCheckoutStats, useSessionSummary } from "@features"
import { formatPrice } from "@utils"

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
        <span>{formatPrice(stats.subtotal)}</span>
      </p>
      <p className="flex justify-between text-xm">
        <span>Tax</span>
        {isPending ? (
          <SkeletonLine />
        ) : (
          <span className="text-neutral-600">
            {!!stats.tax ? formatPrice(stats.tax) : "Enter shipping address"}
          </span>
        )}
      </p>
      <p className="flex justify-between text-xm">
        <span>Shipping</span>
        <span className="text-neutral-600">
          {stats.shippingCost !== undefined
            ? formatPrice(stats.shippingCost)
            : "Enter shipping address"}
        </span>
      </p>
      <p className="flex justify-between text-lg mt-4 font-medium">
        <span>Total</span>
        <span>
          <span className="text-xm font-light text-neutral-600 mr-0.5 tracking-normal">
            EUR
          </span>{" "}
          {formatPrice(stats.total)}
        </span>
      </p>
    </div>
  )
}
export default CheckoutOrderStats
