import { formatPrice } from "@utils"
import { twMerge } from "tailwind-merge"
import SkeletonLine from "../common/SkeletonLine"

interface CostLabelProps extends Omit<React.ComponentProps<"p">, "children"> {
  cost?: number
  noCost?: boolean
  noCostLabel?: string
  isLoading?: boolean
  suffix?: string
}
const CostLabel = ({
  cost,
  noCost,
  noCostLabel,
  className,
  isLoading,
  suffix,
  ...props
}: CostLabelProps) => {
  if (isLoading) {
    return <SkeletonLine />
  }

  return (
    <span
      className={twMerge("relative flex shrink-0 font-medium", className)}
      {...props}
    >
      <span className={noCost ? "line-through scale-95 -translate-y-px" : ""}>
        {!!cost || cost === 0
          ? formatPrice(cost)
          : (noCostLabel ?? "No cost specified")}
      </span>
      {noCost && (
        <span className="ml-0.5 font-semibold text-red-700">
          {formatPrice(0)}
        </span>
      )}
      {!!suffix && <div className="ml-1">{suffix}</div>}
    </span>
  )
}
export default CostLabel
