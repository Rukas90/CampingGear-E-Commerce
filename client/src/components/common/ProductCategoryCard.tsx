import type { ProductCategory } from "@types"

interface ProductCategoryProps {
  category: ProductCategory
}
interface RespresentationData {
  imageSrc: string
  label: string
}
const ProductCategoryCard = ({ imageSrc, label }: RespresentationData) => {
  return (
    <div className="h-60 xs:h-auto group">
      <div className="h-48 xs:h-auto xs:aspect-square bg-[#f1f1ee] rounded-md p-4 shine">
        <img
          src={imageSrc}
          className="w-full h-full object-contain mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
        />
      </div>
      <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
        {label}
      </p>
    </div>
  )
}
export default ProductCategoryCard
