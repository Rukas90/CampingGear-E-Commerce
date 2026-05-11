import { useProductView } from "@features"

const ProductDescription = () => {
  const { data } = useProductView()

  if (!data || !data.description) {
    return
  }

  return (
    <div>
      <p className="text-xl mb-4">Description</p>
      <p>{data.description}</p>
    </div>
  )
}
export default ProductDescription
