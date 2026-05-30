import { TextButton } from "@components/buttons"
import { useCartItem } from "@features"
import { formatPrice } from "@utils"

const EntryHeader = () => {
  const { item } = useCartItem()

  return (
    <>
      <TextButton className="w-fit">{item.brandName}</TextButton>
      <p className="font-medium text-base">{item.productName}</p>
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
    </>
  )
}
export default EntryHeader
