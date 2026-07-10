import { OrderFinancialsStats } from "@components"
import { useCheckoutStats, useSessionSummary } from "@features"

const CheckoutOrderStats = () => {
  const { summary } = useSessionSummary()
  const { stats, isPending } = useCheckoutStats()

  if (!stats) {
    return
  }

  return (
    <OrderFinancialsStats
      itemsCount={summary.cartCount}
      financials={stats.financials}
      freeShippingInfo={stats.freeShippingInfo}
      isPending={isPending}
    />
  )
}
export default CheckoutOrderStats
