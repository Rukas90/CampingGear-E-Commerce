import { OrderFinancialsStats } from "@components"
import { useCartSummary, useCheckoutStats } from "@features"

const CheckoutOrderStats = () => {
  const { summary } = useCartSummary()
  const { stats, isPending } = useCheckoutStats()

  if (!stats) {
    return
  }

  return (
    <OrderFinancialsStats
      itemsCount={summary?.count ?? 0}
      financials={stats.financials}
      freeShippingInfo={stats.freeShippingInfo}
      isPending={isPending}
    />
  )
}
export default CheckoutOrderStats
