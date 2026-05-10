import { useProductView } from "@features"
import ProductOptionHeader from "./ProductOptionHeader"
import clsx from "clsx"
import { IconDiagonalLine, Line } from "@components"
import { PreviewType } from "@types"

const ProductOptionPicker = () => {
  const { sku, data, optionChanged, availableOptionIds } = useProductView()

  const sortedGroups =
    data?.options.sort((a, b) => a.sortOrder - b.sortOrder) ?? []

  return (
    <div className="flex flex-col gap-1">
      {sortedGroups.map((group, index) => {
        const selectedOption = group.options.find((option) =>
          sku?.optionIds.includes(option.id),
        )
        return (
          <div
            key={group.name}
            className={clsx(
              "flex flex-col gap-2",
              index < sortedGroups.length - 1 && "mb-4",
            )}
          >
            <ProductOptionHeader
              key={group.name}
              name={group.name}
              selectedOptionName={selectedOption?.name ?? ""}
              className="ml-0.5"
            />
            <div className="flex gap-2 flex-wrap">
              {group.options
                ?.sort((a, b) => a.sortOrder - b.sortOrder)
                .flatMap((option) => {
                  const isSelected = selectedOption?.id === option.id
                  const isAvailableOption = availableOptionIds.has(option.id)
                  const isOutOfStock = !data?.skus.some(
                    (sku) => sku.optionIds.includes(option.id) && sku.stock > 0,
                  )
                  if (option.previewValue) {
                    const isImage = option.previewType === PreviewType.Image

                    return (
                      <button
                        key={option.id}
                        className={clsx(
                          "size-10 rounded-full p-0.5 border-2",
                          isSelected && "border-neutral-600",
                          !isSelected && "border-neutral-200",
                        )}
                        onClick={() => optionChanged(option.id)}
                        disabled={!isAvailableOption}
                      >
                        <div
                          className="relative w-full h-full rounded-full overflow-hidden"
                          style={{
                            backgroundColor: isImage
                              ? "transparent"
                              : option.previewValue,
                            backgroundImage: isImage
                              ? `url(${option.previewValue})`
                              : undefined,
                          }}
                        >
                          {isOutOfStock && (
                            <IconDiagonalLine className="text-neutral-400" />
                          )}
                        </div>
                      </button>
                    )
                  }

                  return (
                    <button
                      key={option.id}
                      className={clsx(
                        "relative border-2 px-3 py-1.5 rounded-md cursor-pointer",
                        isSelected && "border-neutral-700",
                        !isSelected && "border-neutral-200",
                        isOutOfStock && "text-neutral-400",
                        !isAvailableOption && "opacity-40 cursor-not-allowed",
                        (!isAvailableOption || !isSelected) &&
                          "hover:border-neutral-400",
                      )}
                      onClick={() => optionChanged(option.id)}
                      disabled={!isAvailableOption}
                    >
                      {option.name}
                      {isOutOfStock && (
                        <IconDiagonalLine className="text-neutral-400" />
                      )}
                    </button>
                  )
                })}
            </div>
          </div>
        )
      })}
      {sortedGroups.length > 0 && <Line className="my-4" />}
    </div>
  )
}
export default ProductOptionPicker
