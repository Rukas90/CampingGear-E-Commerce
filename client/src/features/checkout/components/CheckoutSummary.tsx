import CheckoutCart from "./CheckoutCart"
import CheckoutSection from "./CheckoutSection"
import CheckoutOrderStats from "./CheckoutOrderStats"

const CheckoutSummary = () => {
  return (
    <CheckoutSection className="sticky top-0 lg:w-md lg:min-w-md">
      <CheckoutCart />
      <CheckoutOrderStats />
    </CheckoutSection>
  )
}
export default CheckoutSummary
