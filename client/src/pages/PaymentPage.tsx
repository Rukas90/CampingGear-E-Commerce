import { loadStripe } from "@stripe/stripe-js"
import { Elements, PaymentElement } from "@stripe/react-stripe-js"
import { CancelButton, IconLock, Line, SubmitButton } from "@components"

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLISHABLE_KEY)

const PaymentPage = () => {
  return (
    <Elements
      stripe={stripePromise}
      options={{
        mode: "payment",
        amount: 1234,
        currency: "eur",
        appearance: {
          theme: "flat",
          labels: "floating",
          variables: {
            colorPrimary: "#859277",
            colorDanger: "#b06363",
            colorSuccess: "#49ab65",
          },
        },
      }}
    >
      <div className="flex flex-col gap-4 w-full justify-center items-center">
        <div className="mb-2">
          <p className="text-3xl font-semibold text-center mb-1">€72.96</p>
          <p className="text-sm text-neutral-600 text-center">
            Order #xev412vv45
          </p>
        </div>
        <div className="mx-auto min-w-md max-w-full p-6 border-neutral-200 border rounded-lg bg-stone-100">
          <p className="text-base font-semibold mb-3">Order summary</p>
          <p>Line items ...</p>
          <Line className="my-3" />
          <div className="flex flex-col gap-1.5">
            <p className="flex justify-between text-xm text-neutral-600">
              <span>Subtotal</span>
              <span>€57.00</span>
            </p>
            <p className="flex justify-between text-xm text-neutral-600">
              <span>Tax</span>
              <span>€11.97</span>
            </p>
            <p className="flex justify-between text-xm text-neutral-600">
              <span>Shipping - DHL Express</span>
              <span>€3.99</span>
            </p>
          </div>
          <Line className="my-3" />
          <p className="flex justify-between text-sm">
            <span className="font-medium">Total</span>
            <span className="font-medium">€72.96</span>
          </p>
        </div>
        <div className="mx-auto min-w-md max-w-full p-6 border-neutral-200 border rounded-lg">
          <p className="text-base font-semibold mb-3">Payment method</p>

          <PaymentElement
            options={{
              layout: "tabs",
              defaultValues: {},
              fields: {
                billingDetails: "never",
              },
            }}
          />
          <div className="w-full flex flex-col justify-center gap-2 mt-4">
            <SubmitButton className="basis-1/2 py-2 font-semibold">
              Pay €72.96
            </SubmitButton>
            <CancelButton className="basis-1/2 py-2 text-sm">
              Cancel Payment
            </CancelButton>
            <p className="flex items-center gap-1 mx-auto text-xs mt-3 text-neutral-600">
              <IconLock className="size-3.5 text-neutral-500" />{" "}
              <span>Secured by Stripe</span>
            </p>
          </div>
        </div>
      </div>
    </Elements>
  )
}
export default PaymentPage
