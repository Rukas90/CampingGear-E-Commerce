import {
  CheckoutProvider,
  CheckoutForm,
  CheckoutSummary,
  Line,
} from "@features"

const CheckoutPage = () => {
  return (
    <CheckoutProvider>
      <title>Trailstore - Checkout</title>
      <div className="flex flex-1 lg:flex-row flex-col-reverse">
        <div className="relative flex flex-col flex-1 basis-[54%] bg-white">
          <CheckoutForm />
          <Line vertical className="absolute top-0 right-0 text-neutral-200" />
        </div>
        <div className="flex flex-col flex-1 basis-[46%]">
          <CheckoutSummary />
        </div>
      </div>
    </CheckoutProvider>
  )
}
export default CheckoutPage
