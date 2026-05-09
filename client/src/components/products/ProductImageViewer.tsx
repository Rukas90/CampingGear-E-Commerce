import { ImageViewer } from "@components"
import { useProductView } from "@features"

const ProductImageViewer = () => {
  const { images } = useProductView()

  return (
    <ImageViewer
      imagePaths={
        images
          ?.sort((a, b) => a.sortOrder - b.sortOrder)
          .flatMap((img) => img.url) ?? []
      }
    />
  )
}
export default ProductImageViewer
