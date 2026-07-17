import { TextButton } from "@components/buttons"
import { useCartItem } from "@features"
import { formatPrice } from "@utils"

const EntryHeader = () => {
  const { item } = useCartItem()

  return (
    <div className="flex flex-col gap-1">
      <TextButton className="w-fit sm:text-sm text-xs text-start">
        {item.brandName}
      </TextButton>
      <p className="font-medium sm:text-base text-sm">{item.productName}</p>
      <div>
        <p className="text-xm my-0.5">{formatPrice(item.unitPrice)}</p>
        <div className="my-1">
          <p className="text-xs text-neutral-500">
            {item.options
              .map((option) => `${option.groupName}: ${option.valueName}`)
              .join(" · ")}
          </p>
        </div>
      </div>
    </div>
  )
}
export default EntryHeader
