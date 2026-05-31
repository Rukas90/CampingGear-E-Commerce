import { Toggle } from "@components"
import type { ShippingMethod } from "@types"
import { formatPrice } from "@utils"
import clsx from "clsx"
import { twMerge } from "tailwind-merge"

interface ShippingMethodItemProps {
  method: ShippingMethod
  selected?: boolean
  isFree?: boolean
  className?: string
  disabled?: boolean
}
const ShippingMethodItem = ({
  method,
  selected,
  isFree,
  className,
  disabled,
}: ShippingMethodItemProps) => {
  return (
    <li
      className={twMerge(
        "flex gap-4 p-4 border rounded-lg transition-colors bg-accent-overlay border-accent",
        className,
      )}
    >
      <Toggle checked={selected} disabled={disabled} />
      <div className="flex flex-col gap-1 text-start grow">
        <p className="text-xm font-semibold">{method.name}</p>
        <p className="text-xs text-neutral-600">{method.description}</p>
      </div>
      <p
        className={clsx(
          "relative flex text-xm shrink-0 font-medium",
          isFree && "line-through text-red-700",
        )}
      >
        {formatPrice(method.flatFee)}
      </p>
    </li>
  )
}
export default ShippingMethodItem
