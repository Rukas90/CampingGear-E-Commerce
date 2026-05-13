import {
  CatalogFiltersSidebar,
  PageWrapper,
  ProductItem,
  ProductsCategoryListingHeader,
} from "@components"
import { useCategoryProductsQuery, useFilters } from "@features"
import { useParams, useSearchParams } from "react-router-dom"

const ProductsPage = () => {
  const [searchParams] = useSearchParams()
  const { category } = useParams()
  const { catalogFilters } = useFilters({
    searchParams,
    overrides: { queryCategory: category! },
  })
  const { products } = useCategoryProductsQuery({
    searchParams,
    overrides: { category: [category!] },
  })

  if (!catalogFilters) {
    return
  }

  return (
    <PageWrapper className="w-full">
      {category && <ProductsCategoryListingHeader categorySlug={category} />}
      <div className="relative items-start flex gap-12 py-12 w-full">
        <CatalogFiltersSidebar {...catalogFilters} exclude={["categories"]} />
        <div className="grid grid-cols-3 self-start grow max-w-full">
          {products
            ?.sort((a, b) => (b.inStock ? 1 : 0) - (a.inStock ? 1 : 0))
            .map((summary) => (
              <ProductItem {...summary} />
            ))}
        </div>
        {(products?.length ?? 0) <= 0 && (
          <p className="w-full text-center pt-12 text-lg text-neutral-400">
            No products found
          </p>
        )}
      </div>
    </PageWrapper>
  )
}
export default ProductsPage
