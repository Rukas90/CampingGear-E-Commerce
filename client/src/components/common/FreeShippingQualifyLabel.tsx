import { formatPrice } from "@utils"

interface FreeShippingQualifyLabelProps {
  subtotal: number
  freeShippingThreshold?: number
}
const FreeShippingQualifyLabel = ({
  subtotal,
  freeShippingThreshold,
}: FreeShippingQualifyLabelProps) => {
  if (freeShippingThreshold === undefined) {
    return <></>
  }
  const eligible = subtotal >= freeShippingThreshold

  if (eligible) {
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
        {formatPrice(freeShippingThreshold - subtotal)}
      </span>{" "}
      of eligible items to your order to qualify for FREE Shipping.
    </p>
  )
}
export default FreeShippingQualifyLabel
