import { formatPrice } from "@utils"
import { twMerge } from "tailwind-merge"
import SkeletonLine from "./SkeletonLine"

interface CostLabelProps extends Omit<React.ComponentProps<"p">, "children"> {
  cost?: number
  isFree?: boolean
  noCostLabel?: string
  isLoading?: boolean
  suffix?: string
}
const CostLabel = ({
  cost,
  isFree,
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
    <p
      className={twMerge("relative flex shrink-0 font-medium", className)}
      {...props}
    >
      <span className={isFree ? "line-through scale-95 -translate-y-px" : ""}>
        {!!cost || cost === 0
          ? formatPrice(cost)
          : (noCostLabel ?? "No cost specified")}
      </span>
      {isFree && (
        <span className="ml-0.5 font-semibold text-red-700">
          {formatPrice(0)}
        </span>
      )}
      {!!suffix && <div className="ml-1">{suffix}</div>}
    </p>
  )
}
export default CostLabel
