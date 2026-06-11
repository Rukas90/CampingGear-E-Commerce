import { ImageViewer } from "@components"
import { useProductView } from "@features"
import { useMemo } from "react"

const ProductImageViewer = () => {
  const { images } = useProductView()

  const imagePaths = useMemo(
    () =>
      images
        ?.sort((a, b) => a.sortOrder - b.sortOrder)
        .flatMap((img) => img.url) ?? [],
    [images],
  )

  return <ImageViewer imagePaths={imagePaths} />
}
export default ProductImageViewer
