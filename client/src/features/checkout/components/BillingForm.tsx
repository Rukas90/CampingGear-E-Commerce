import { AddressForm, LabeledToggle, Line, useCheckoutBilling } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"

const ShippingForm = () => {
  const { billing, isBusy } = useCheckoutBilling()

  const asShippingAddress = billing.value("asShippingAddress")

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        onEdit={billing.edit}
        isEditing={billing.isEditing}
      >
        Billing address
      </FormHeader>
      <LabeledToggle
        label="Use shipping address as billing address"
        checked={asShippingAddress.value()}
        onChange={(value) => asShippingAddress.update(value)}
        disabled={!billing.isEditing || isBusy}
      />
      {!asShippingAddress.value() && (
        <>
          <Line className="bg-neutral-200 mt-2.5 mb-5" />
          <AddressForm
            field={billing.field("address")}
            disabled={!billing.isEditing || isBusy}
          />
        </>
      )}
      <FormEditNav
        isBusy={isBusy}
        isEditing={billing.isEditing}
        isDirty={billing.isDirty()}
        onCancel={billing.cancel}
        onCommit={billing.commit}
      />
    </div>
  )
}
export default ShippingForm
