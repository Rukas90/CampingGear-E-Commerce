import { useSessionSummary } from "@features"
import CheckoutCart from "./CheckoutCart"
import CheckoutSection from "./CheckoutSection"
import { formatPrice } from "@utils"

const CheckoutSummary = () => {
  const { summary } = useSessionSummary()

  return (
    <CheckoutSection className="sticky top-0 lg:w-md lg:min-w-md">
      <CheckoutCart />
      <div className="flex flex-col gap-1.5 mt-6">
        <p className="flex justify-between text-[13px]">
          <span>Subtotal · {summary.cartCount} items</span>
          <span>{formatPrice(1254)}</span>
        </p>
        <p className="flex justify-between text-[13px]">
          <span>Shipping</span>
          <span className="text-neutral-600">Enter shipping address</span>
        </p>
        <p className="flex justify-between text-lg mt-4 font-medium">
          <span>Total</span>
          <span>
            <span className="text-[13px] font-light text-neutral-600 mr-0.5 tracking-normal">
              EUR
            </span>{" "}
            {formatPrice(1254)}
          </span>
        </p>
      </div>
    </CheckoutSection>
  )
}
export default CheckoutSummary
