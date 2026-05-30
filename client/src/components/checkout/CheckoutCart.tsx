import { CartItemsProvider } from "@features"
import CheckoutCartItem from "./CheckoutCartItem"
import { Line, CartEntriesList, TextButton } from "@components"

const CheckoutCart = () => {
  return (
    <div>
      <div className="flex items-center justify-between">
        <p className="font-medium">Your shopping cart</p>
        <a href="/cart">
          <TextButton>Edit</TextButton>
        </a>
      </div>
      <Line className="bg-neutral-200 my-2" />
      <CartItemsProvider>
        <CartEntriesList
          className="px-0 overflow-y-auto"
          renderItem={(item) => <CheckoutCartItem item={item} />}
        />
      </CartItemsProvider>
    </div>
  )
}
export default CheckoutCart
