import { formatPrice } from "@utils"

interface FreeShippingQualifyLabelProps {
  addCostForFreeShipping?: number
  eligibleForFreeShipping?: boolean
}
const FreeShippingQualifyLabel = ({
  addCostForFreeShipping,
  eligibleForFreeShipping,
}: FreeShippingQualifyLabelProps) => {
  if (
    eligibleForFreeShipping === undefined ||
    addCostForFreeShipping === undefined
  ) {
    return <></>
  }
  if (eligibleForFreeShipping) {
    return (
      <p className="text-xs text-lime-800">
        ✓ Your order qualifies for FREE shipping!
      </p>
    )
  }

  return (
    <p className="text-xs text-neutral-800">
      Add{" "}
      <span className="text-red-800">
        {formatPrice(addCostForFreeShipping)}
      </span>{" "}
      of eligible items to your order to qualify for FREE Shipping.
    </p>
  )
}
export default FreeShippingQualifyLabel
