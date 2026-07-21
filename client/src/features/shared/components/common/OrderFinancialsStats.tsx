import type { Financials, FreeShippingInfo } from "@types"
import CostLabel from "../labels/CostLabel"
import FreeShippingQualifyLabel from "./FreeShippingQualifyLabel"

interface OrderFinancialsStatsProps {
  financials?: Financials
  itemsCount?: number
  freeShippingInfo?: FreeShippingInfo
  isPending?: boolean
}

const OrderFinancialsStats = ({
  financials,
  itemsCount,
  freeShippingInfo,
  isPending,
}: OrderFinancialsStatsProps) => {
  return (
    <div className="flex flex-col gap-1.5 mt-6">
      {!!freeShippingInfo && (
        <div className="mb-2">
          <FreeShippingQualifyLabel
            eligibleForFreeShipping={freeShippingInfo.eligibleForFreeShipping}
            addCostForFreeShipping={freeShippingInfo.addCostForFreeShipping}
          />
        </div>
      )}
      <p className="flex justify-between text-xm">
        <span>Subtotal {itemsCount && <span> · {itemsCount} items</span>}</span>
        <CostLabel
          className="font-normal"
          cost={financials?.subtotal ?? 0}
          isLoading={isPending}
        />
      </p>
      <p className="flex justify-between text-xm">
        <span>Tax</span>
        <CostLabel
          className="text-neutral-700 font-normal"
          cost={financials?.tax ?? 0}
          noCostLabel="Enter shipping address"
          isLoading={isPending}
        />
      </p>
      <p className="flex justify-between text-xm">
        <span>Shipping</span>
        <CostLabel
          className="text-neutral-700 font-normal"
          cost={financials?.shippingCost ?? 0}
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
            cost={financials?.total ?? financials?.subtotal ?? 0}
            isLoading={isPending}
          />
        </div>
      </div>
    </div>
  )
}
export default OrderFinancialsStats
