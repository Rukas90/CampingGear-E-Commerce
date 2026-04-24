import { ProductCategoryCard, SectionContainer } from "@components"
import { useTopCategories } from "@features"

const TopCategories = () => {
  const { data } = useTopCategories({ count: 6 })

  return (
    <SectionContainer className="grid lg:grid-cols-6 md:grid-cols-4 sm:grid-cols-2 xs:grid-cols-1 gap-4">
      {data?.map((c) => (
        <ProductCategoryCard imageSrc={c.imageUrl ?? ""} label={c.name} />
      ))}
    </SectionContainer>
  )
}
export default TopCategories
