import { IconAccount, IconThumbUp, RatingStars } from "@components"

const ProductReviewItem = () => {
  return (
    <div className="flex flex-col gap-4 py-4">
      <div className="flex justify-between">
        <RatingStars rating={5} className="size-4" />
        <p className="text-sm text-stone-400">04/11-2024</p>
      </div>
      <div className="flex gap-2.5 text-lg">
        <div className="bg-stone-200 size-10 rounded-lg p-1.5">
          <IconAccount className="text-stone-400" />
        </div>
        <p className="text-stone-800">Kennedy B.</p>
      </div>
      <p className="text-lg font-medium">Pre camping review</p>
      <p>
        This tent was very intuitive to set up, I watched some YouTube videos
        and pitched a perfect pitch first time. Heaps of room and so light. I
        will be selling my Zpacks Pleximid asap.
      </p>
      <div className="flex gap-4 justify-end">
        <div className="flex gap-2 items-center">
          <IconThumbUp className="size-5.5 text-stone-800" />
          <p className="text-base pt-1">11</p>
        </div>
        <div className="flex gap-2 items-center">
          <IconThumbUp className="size-5.5 rotate-180 mt-1 text-stone-800" />
          <p className="text-base pt-1">2</p>
        </div>
      </div>
    </div>
  )
}
export default ProductReviewItem
