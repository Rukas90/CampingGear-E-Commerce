import { CancelButton, SubmitButton } from "@components"
import { PaymentElement } from "@stripe/react-stripe-js"
import SecuredBadge from "../badges/SecuredBadge"
import PaymentOrderSummary from "./PaymentOrderSummary"
import { usePaymentContext } from "@features"
import { formatPrice } from "@utils"

const PaymentForm = () => {
  const { order, actions, state } = usePaymentContext()

  const isBusy = state !== "idle"

  return (
    <div className="flex flex-col gap-4 w-full justify-center items-center py-12">
      <PaymentOrderSummary order={order} />
      <p>{state}</p>
      <div className="mx-auto min-w-md max-w-full p-6 border-neutral-200 border rounded-lg">
        <p className="text-base font-semibold mb-3">Payment method</p>
        <PaymentElement
          options={{
            layout: "tabs",
            defaultValues: {},
            fields: {
              billingDetails: "never",
            },
            wallets: {
              link: "never",
            },
          }}
        />
        <div className="w-full flex flex-col justify-center gap-2 mt-4">
          <SubmitButton
            className="basis-1/2 py-2 font-semibold"
            onClick={actions.confirm}
            isLoading={isBusy}
          >
            Pay {formatPrice(order.financials.total)}
          </SubmitButton>
          <CancelButton
            className="basis-1/2 py-2 text-sm"
            isLoading={isBusy}
            onClick={actions.cancel}
          >
            Cancel Payment
          </CancelButton>
          <SecuredBadge />
        </div>
      </div>
    </div>
  )
}
export default PaymentForm
