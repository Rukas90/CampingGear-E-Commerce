import { Line, RatingBadge, Text, useProductView } from "@features"

const ProductSummary = () => {
  const { sku, data, isPending } = useProductView()

  return (
    <div className="flex flex-col gap-1">
      <Text
        className="text-lg text-neutral-400"
        showSkeleton={isPending}
        skeleton={{
          className: "w-32! max-w-full!",
        }}
      >
        {data?.brandName}
      </Text>
      <Text
        className="text-3xl font-semibold mb-2"
        showSkeleton={isPending}
        skeleton={{
          className: "h-8 w-64! max-w-full!",
        }}
      >
        {data?.name}
      </Text>
      <Text
        className="text-xl text-accent font-semibold"
        showSkeleton={isPending}
        skeleton={{
          className: "h-5 w-14! max-w-full!",
        }}
      >
        {sku?.unitPrice}€
      </Text>
      <p className="italic text-neutral-400 text-sm">Excluding Tax</p>
      <a href="#customer-reviews">
        <RatingBadge
          starsClassName="size-4"
          averageRating={data?.averageRating ?? 0}
          reviewCount={data?.reviewCount ?? 0}
          className="mt-2 text-base"
        />
      </a>
      <Line className="my-4" />
    </div>
  )
}
export default ProductSummary
