import type { ShippingMethod, ShippingMethodId } from "@types"
import clsx from "clsx"
import ShippingMethodItem from "./ShippingMethodItem"

interface ShippingMethodSelectionProps {
  selectedId?: ShippingMethodId
  methods?: ShippingMethod[]
  eligibleForFreeShipping?: boolean
  onSelected?: (methodId: ShippingMethodId) => void
  disabled?: boolean
  isEditing?: boolean
}
const ShippingMethodSelection = ({
  selectedId,
  methods,
  eligibleForFreeShipping,
  onSelected,
  disabled,
  isEditing,
}: ShippingMethodSelectionProps) => {
  if (!methods || methods.length <= 0) {
    return (
      <p className="text-center text-xs py-4 px-8 bg-neutral-100 rounded-lg text-neutral-500">
        Enter shipping address to view available shipping methods.
      </p>
    )
  }

  const currentMethod = methods.find((method) => method.id === selectedId)

  if (!currentMethod) {
    return (
      <p className="text-center text-xs py-4 px-8 bg-neutral-100 rounded-lg text-neutral-500">
        No shipping method selected.
      </p>
    )
  }

  if (!isEditing) {
    return (
      <ShippingMethodItem
        method={currentMethod}
        isFree={eligibleForFreeShipping}
        selected
      />
    )
  }

  return (
    <ul className="flex flex-col">
      {methods.map((method, index) => {
        const isSelected = method.id === selectedId
        const isFirst = index === 0
        const isLast = index === methods.length - 1
        const prevSelected = !isFirst && methods[index - 1].id === selectedId
        const topBorderAccent = isSelected || prevSelected

        return (
          <button
            disabled={disabled}
            onClick={() => onSelected?.(method.id)}
            className="cursor-pointer"
          >
            <ShippingMethodItem
              method={method}
              selected={isSelected}
              isFree={eligibleForFreeShipping}
              disabled={disabled}
              className={clsx(
                isFirst && "rounded-t-lg rounded-b-none border-b-0",
                isLast && "rounded-b-lg rounded-t-none border-b",
                !isFirst && !isLast && "rounded-none border-b-0",

                !disabled &&
                  (isSelected
                    ? "bg-accent-overlay border-accent"
                    : "bg-transparent border-neutral-300"),

                disabled &&
                  (isSelected
                    ? "bg-neutral-100 border-neutral-400"
                    : "bg-transparent border-neutral-200"),

                !disabled &&
                  !isSelected &&
                  topBorderAccent &&
                  "border-t-accent",

                disabled &&
                  !isSelected &&
                  topBorderAccent &&
                  "border-t-neutral-400",
              )}
            />
          </button>
        )
      })}
    </ul>
  )
}
export default ShippingMethodSelection
