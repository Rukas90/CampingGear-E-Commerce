import { IconDiagonalLine } from "@components"
import { PreviewType, type ProductOption } from "@types"
import clsx from "clsx"

interface OptionButtonProps {
  isSelected: boolean
  isAvailable: boolean
  isOutOfStock: boolean
  onClick: () => void
  option: ProductOption
}

export const PreviewOptionButton = ({
  isSelected,
  isAvailable,
  isOutOfStock,
  onClick,
  option,
}: OptionButtonProps) => (
  <button
    className={clsx(
      "size-10 rounded-full p-0.5 border-2",
      isSelected ? "border-neutral-600" : "border-neutral-200",
    )}
    onClick={onClick}
    disabled={!isAvailable}
  >
    <div
      className="relative w-full h-full rounded-full overflow-hidden"
      style={{
        backgroundColor:
          option.previewType === PreviewType.Image
            ? "transparent"
            : option.previewValue,
        backgroundImage:
          option.previewType === PreviewType.Image
            ? `url(${option.previewValue})`
            : undefined,
      }}
    >
      {isOutOfStock && <IconDiagonalLine className="text-neutral-400" />}
    </div>
  </button>
)

export const TextOptionButton = ({
  isSelected,
  isAvailable,
  isOutOfStock,
  onClick,
  option,
}: OptionButtonProps) => (
  <button
    className={clsx(
      "relative border-2 px-3 py-1.5 rounded-md cursor-pointer",
      isSelected ? "border-neutral-700" : "border-neutral-200",
      isOutOfStock && "text-neutral-400",
      !isAvailable && "opacity-40 cursor-not-allowed",
      (!isAvailable || !isSelected) && "hover:border-neutral-400",
    )}
    onClick={onClick}
    disabled={!isAvailable}
  >
    {option.name}
    {isOutOfStock && <IconDiagonalLine className="text-neutral-400" />}
  </button>
)
