import type { ProductCategory } from "@types"

interface ProductCategoryProps {
  category: ProductCategory
}
interface RespresentationData {
  imageSrc: string
  label: string
}
const CategoryRepresentation: Record<ProductCategory, RespresentationData> = {
  handheld_gps: {
    imageSrc: "products/gpsmap67/gpsmap-67-xl.webp",
    label: "Handheld GPS",
  },
  tent: {
    imageSrc: "products/tents/durston-x-mid-pro-1---3.webp",
    label: "Tents",
  },
  backpack: {
    imageSrc: "products/backpacks/gregory-baltoro-75-man.webp",
    label: "Backpacks",
  },
  sleeping_bag: {
    imageSrc: "products/sleeping-bags/western-mountaineering-alpinlite-20.webp",
    label: "Sleeping Bags",
  },
}
const ProductCategoryCard = ({ category }: ProductCategoryProps) => {
  const representation = CategoryRepresentation[category]

  return (
    <div className="h-60 xs:h-auto group">
      <div className="h-48 xs:h-auto xs:aspect-square bg-[#f1f1ee] rounded-md p-4 shine">
        <img
          src={representation.imageSrc}
          className="w-full h-full object-contain mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
        />
      </div>
      <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
        {representation.label}
      </p>
    </div>
  )
}
export default ProductCategoryCard
