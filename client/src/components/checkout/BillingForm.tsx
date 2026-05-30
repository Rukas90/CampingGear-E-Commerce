import { AddressForm, LabeledToggle, Line } from "@components"
import { useCheckoutBilling } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"

const ShippingForm = () => {
  const { data, isBusy } = useCheckoutBilling()

  const asShippingAddress = data.value("asShippingAddress")

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        onEdit={data.edit}
        isEditing={data.isEditing}
      >
        Billing address
      </FormHeader>
      <LabeledToggle
        label="Use shipping address as billing address"
        checked={asShippingAddress.value()}
        onChange={(value) => asShippingAddress.update(value)}
        disabled={!data.isEditing || isBusy}
      />
      {!asShippingAddress.value() && (
        <>
          <Line className="bg-neutral-200 mt-2.5 mb-5" />
          <AddressForm
            field={data.field("address")}
            disabled={!data.isEditing || isBusy}
          />
        </>
      )}
      <FormEditNav
        isBusy={isBusy}
        isEditing={data.isEditing}
        isDirty={data.isDirty()}
        onCancel={data.cancel}
        onCommit={data.commit}
      />
    </div>
  )
}
export default ShippingForm
