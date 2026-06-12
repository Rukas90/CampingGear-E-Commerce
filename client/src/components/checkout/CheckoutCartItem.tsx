import { CostLabel, DotCount } from "@components"
import type { CartItem } from "@types"

const CheckoutCartItem = ({ item }: { item: CartItem }) => {
  return (
    <div className="flex">
      <div className="relative flex w-16 min-h-16 p-0.5 rounded-lg my-2 bg-white drop-shadow-sm drop-shadow-neutral-200">
        <div className="flex border border-neutral-200 w-full h-full p-0.5 rounded-lg shine">
          <img
            className="object-contain mix-blend-darken w-16 aspect-square mx-auto"
            src={item.thumbnailUrl}
          />
        </div>
        <DotCount
          count={item.quantity}
          className="-top-0.5 -right-1 text-[12px] font-normal text-white max-w-5.25 min-w-5.25 h-5.25"
        />
      </div>
      <div className="flex gap-0.5 flex-col py-3 pl-3 w-full">
        <div className="flex justify-between w-full">
          <p className="text-xs text-accent">{item.brandName}</p>
          <CostLabel
            className="ml-auto text-xs font-medium"
            cost={item.unitPrice * item.quantity}
          />
        </div>
        <p className="text-[0.8rem]">{item.productName}</p>
        <p className="text-xs text-neutral-500">
          {" "}
          {item.options
            .map((option) => `${option.groupName}: ${option.valueName}`)
            .join(" · ")}
        </p>
      </div>
    </div>
  )
}
export default CheckoutCartItem
