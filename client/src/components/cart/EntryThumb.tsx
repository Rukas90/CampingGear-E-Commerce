import { useCartItem } from "@features"

const EntryThumb = () => {
  const { item } = useCartItem()

  return (
    <div className="flex justify-center items-center bg-stone-200 p-2 rounded-lg">
      <img
        src={item.thumbnailUrl}
        className="mix-blend-darken size-22 shrink-0 object-contain"
      />
    </div>
  )
}
export default EntryThumb
