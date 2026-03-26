import { FreeShippingNote, IconArrow } from "@components"

const Feed = () => {
  return (
    <div className="w-full p-4 bg-[#ad594e]">
      <div className="flex gap-4 justify-center items-center">
        <IconArrow className="text-stone-50 size-4.5 rotate-180" />
        <FreeShippingNote />
        <IconArrow className="text-stone-50 size-4.5" />
      </div>
    </div>
  )
}
export default Feed
