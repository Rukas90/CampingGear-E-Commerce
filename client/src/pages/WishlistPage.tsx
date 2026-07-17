import {
  BrowseProductsButton,
  Line,
  PageWrapper,
  WishlistCard,
} from "@components"
import { useWishlist } from "@features"

const WishlistPage = () => {
  const { items, removeItem, busy } = useWishlist()

  const hasItems = (items?.length ?? 0) > 0

  return (
    <PageWrapper className="w-full my-12">
      <title>Trailstore - Wishlist</title>
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
          <p className="mt-4 text-center text-sm text-neutral-600 mb-8">
            You currently do not have any products in the wishlist.
          </p>
          <BrowseProductsButton />
        </div>
      )}
    </PageWrapper>
  )
}
export default WishlistPage
