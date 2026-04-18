import {
  Button,
  HeaderText,
  PageWrapper,
  ProductCategoryCard,
  SectionContainer,
} from "@components"
import Banner from "/img/banner.webp"
import { useCategories } from "@features"
import { useEffect } from "react"

const HomePage = () => {
  const { data } = useCategories()

  useEffect(() => {
    data?.map((c) => console.log(JSON.stringify(c)))
  }, [data])

  return (
    <>
      <div className="flex justify-center w-full">
        <p className="flex flex-col items-center pt-10 text-2xl gap-1">
          <span className="font-semibold">Find the latest Camping Gear</span>
          <span>from the most respectable brands </span>
          <span className="flex gap-4">
            <Button fill="outline">Shop All</Button>
            <Button style="contrast">Shop New</Button>
          </span>
        </p>
      </div>
      <img
        src={Banner}
        className="relative w-full object-cover object-bottom-right -translate-y-6 pointer-events-none"
      />
      <PageWrapper className="mt-6">
        <div className="flex justify-between">
          <HeaderText>Top categories</HeaderText>
          <p className="text-lg">All categories -</p>
        </div>
        <SectionContainer className="grid lg:grid-cols-6 md:grid-cols-4 sm:grid-cols-2 xs:grid-cols-1 gap-4">
          <ProductCategoryCard category="handheld_gps" />
          <ProductCategoryCard category="tent" />
          <ProductCategoryCard category="backpack" />
          <ProductCategoryCard category="sleeping_bag" />
          <ProductCategoryCard category="backpack" />
          <ProductCategoryCard category="tent" />
        </SectionContainer>
      </PageWrapper>
    </>
  )
}
export default HomePage
