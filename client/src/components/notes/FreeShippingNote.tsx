import { IconCart } from "@components"

const FreeShippingNote = () => {
  return (
    <div className="flex gap-2 justify-center items-center text-stone-50">
      <IconCart className="size-5" />
      <p>
        <span className="font-semibold">Free Shipping </span>
        On Orders $150+
      </p>
    </div>
  )
}
export default FreeShippingNote
