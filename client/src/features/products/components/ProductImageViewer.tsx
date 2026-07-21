import { ImageViewer, useProductView } from "@features"
import { useMemo } from "react"
import Skeleton from "react-loading-skeleton"

const ProductImageViewer = () => {
  const { images, isPending } = useProductView()

  const imagePaths = useMemo(
    () =>
      images
        ?.sort((a, b) => a.sortOrder - b.sortOrder)
        .flatMap((img) => img.url) ?? [],
    [images],
  )

  if (isPending) {
    return <Skeleton className="h-full aspect-square" />
  }

  return <ImageViewer imagePaths={imagePaths} />
}
export default ProductImageViewer
