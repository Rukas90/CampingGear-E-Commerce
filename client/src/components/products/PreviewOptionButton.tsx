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

const PreviewOptionButton = ({
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
export default PreviewOptionButton
