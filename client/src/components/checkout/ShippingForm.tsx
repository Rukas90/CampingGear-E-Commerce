import { AddressForm } from "@components"
import { useCheckoutShipping } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"

const ShippingForm = () => {
  const { data, isBusy } = useCheckoutShipping()

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        onEdit={data.edit}
        isEditing={data.isEditing}
      >
        Shipping address
      </FormHeader>
      <AddressForm
        field={data.asField()}
        disabled={!data.isEditing || isBusy}
      />
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
