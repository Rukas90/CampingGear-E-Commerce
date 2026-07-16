import { ContrastButton, Line, PageWrapper, WishlistCard } from "@components"
import { useCategories, useWishlist } from "@features"
import { useNavigate } from "react-router-dom"

const WishlistPage = () => {
  const { items, removeItem, busy } = useWishlist()
  const { data } = useCategories()
  const navigate = useNavigate()

  const hasItems = (items?.length ?? 0) > 0

  const handleBrowseClick = () => {
    const randomCategory = data?.length
      ? data[Math.floor(Math.random() * data.length)]
      : null

    navigate(randomCategory ? `/products/${randomCategory.slug}` : "/")
  }

  return (
    <PageWrapper className="w-full my-12">
      <p className="text-3xl font-semibold">My Wishlist</p>
      <Line className="bg-neutral-300 my-4" />
      <div className="grid lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-2 gap-6">
        {items?.map((item) => (
          <WishlistCard
            key={item.skuId}
            item={item}
            onRemove={() => removeItem(item.skuId)}
            disabled={busy}
          />
        ))}
      </div>
      {!hasItems && (
        <div className="flex flex-col">
          <p className="mt-4 text-center text-sm text-neutral-600">
            You currently do not have any products in the wishlist.
          </p>
          <ContrastButton
            className="mx-auto py-2.5 px-4 mt-8"
            onClick={handleBrowseClick}
          >
            Browse products
          </ContrastButton>
        </div>
      )}
    </PageWrapper>
  )
}
export default WishlistPage
