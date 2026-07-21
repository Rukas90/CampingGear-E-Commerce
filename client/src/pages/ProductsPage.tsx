import {
  CatalogFiltersSidebar,
  PageWrapper,
  ProductItem,
  ProductsCategoryListingHeader,
  useCategoryProductsQuery,
  useFilters,
} from "@features"
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
      <div className="flex sm:flex-row flex-col justify-between sm:items-end items-center mt-8">
        {category && <ProductsCategoryListingHeader categorySlug={category} />}
        <p className="sm:text-base text-xs ml-auto sm:mr-0 mr-auto text-neutral-400">
          {products?.length} products
        </p>
      </div>
      <div className="relative items-start flex sm:flex-row flex-col gap-12 py-12 w-full">
        <CatalogFiltersSidebar {...catalogFilters} exclude={["categories"]} />
        <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 self-start grow max-w-full">
          {products
            ?.sort((a, b) => (b.inStock ? 1 : 0) - (a.inStock ? 1 : 0))
            .map((summary) => (
              <ProductItem key={summary.slug} {...summary} />
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
