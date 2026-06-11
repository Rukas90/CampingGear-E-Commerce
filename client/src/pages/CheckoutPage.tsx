import { CheckoutForm, CheckoutSummary, Line } from "@components"
import { CheckoutProvider } from "@features"

const CheckoutPage = () => {
  return (
    <CheckoutProvider>
      <div className="relative flex flex-col flex-1 basis-[54%] bg-white">
        <CheckoutForm />
        <Line vertical className="absolute top-0 right-0 text-neutral-200" />
      </div>
      <div className="flex flex-col flex-1 basis-[46%]">
        <CheckoutSummary />
      </div>
    </CheckoutProvider>
  )
}
export default CheckoutPage
