import { useProductView } from "@features"
import Markdown from "react-markdown"

const ProductDescription = () => {
  const { data } = useProductView()

  if (!data || !data.description) {
    return
  }

  return (
    <div>
      <p className="text-xl mb-4">Description</p>
      <div className="prose max-w-none">
        <Markdown>{data.description}</Markdown>
      </div>
    </div>
  )
}
export default ProductDescription
