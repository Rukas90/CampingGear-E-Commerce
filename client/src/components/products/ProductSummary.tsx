import { useProductView } from "@features"
import RatingBadge from "./RatingBadge"
import { Line } from "@components"

const ProductSummary = () => {
  const { sku, data } = useProductView()

  return (
    <div className="flex flex-col gap-1">
      <p className="text-lg text-neutral-400">{data?.brandName}</p>
      <p className="text-3xl font-semibold mb-2">{data?.name}</p>
      <p className="text-xl text-lime-800 font-semibold">{sku?.unitPrice}€</p>
      <p className="italic text-neutral-400">Tax included</p>
      <RatingBadge
        starsClassName="size-4"
        averageRating={data?.averageRating ?? 0}
        reviewCount={data?.reviewCount ?? 0}
        className="mt-2 text-base"
      />
      <Line className="my-4" />
    </div>
  )
}
export default ProductSummary
