import { useProductView } from "@features"
import ProductOptionHeader from "./ProductOptionHeader"
import clsx from "clsx"
import { Line } from "@components"
import { PreviewOptionButton, TextOptionButton } from "./OptionButtons"

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
                  const props = {
                    isSelected: selectedOption?.id === option.id,
                    isAvailable: availableOptionIds.has(option.id),
                    isOutOfStock: !data?.skus.some(
                      (s) => s.optionIds.includes(option.id) && s.stock > 0,
                    ),
                    onClick: () => optionChanged(option.id),
                    option,
                  }

                  return option.previewValue ? (
                    <PreviewOptionButton key={option.id} {...props} />
                  ) : (
                    <TextOptionButton key={option.id} {...props} />
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
