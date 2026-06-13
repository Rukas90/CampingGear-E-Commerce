import { CancelButton, Line, SubmitButton } from "@components"
import { PaymentElement } from "@stripe/react-stripe-js"
import type { OrderToken } from "@types"
import PaymentCostLabel from "./PaymentCostLabel"
import SecuredBadge from "./SecuredBadge"

interface PaymentFormProps {
  token: OrderToken
}
const PaymentForm = ({ token }: PaymentFormProps) => {
  return (
    <div className="flex flex-col gap-4 w-full justify-center items-center py-12">
      <div className="mb-2">
        <p className="text-3xl font-semibold text-center mb-1">€72.96</p>
        <p className="text-sm text-neutral-600 text-center">Order #{token}</p>
      </div>
      <div className="mx-auto min-w-md max-w-full p-6 border-neutral-200 border rounded-lg bg-stone-100">
        <p className="text-base font-semibold mb-3">Order summary</p>
        <p>Line items ...</p>
        <Line className="my-3" />
        <div className="flex flex-col gap-1.5">
          <PaymentCostLabel label="Subtotal" price={57} />
          <PaymentCostLabel label="Tax" price={11.97} />
          <PaymentCostLabel label="Shipping - DHL Express" price={3.99} />
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
          <SecuredBadge />
        </div>
      </div>
    </div>
  )
}
export default PaymentForm
