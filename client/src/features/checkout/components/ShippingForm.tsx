import { AddressForm, useCheckoutShipping, useCheckoutStats } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"
import ShippingMethodSelection from "./ShippingMethodSelection"

const ShippingForm = () => {
  const { address, method, availableMethods, isBusy } = useCheckoutShipping()
  const { stats } = useCheckoutStats()

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        onEdit={address.edit}
        isEditing={address.isEditing}
      >
        Delivery
      </FormHeader>
      <AddressForm
        field={address.asField()}
        disabled={!address.isEditing || isBusy}
      />
      <FormEditNav
        isBusy={isBusy}
        isEditing={address.isEditing}
        isDirty={address.isDirty()}
        onCancel={address.cancel}
        onCommit={address.commit}
      />
      <div className="mt-6">
        <FormHeader
          isLoading={isBusy}
          onEdit={method.edit}
          isEditing={method.isEditing}
          className="text-base font-semibold"
        >
          Shipping method
        </FormHeader>
        <ShippingMethodSelection
          selectedId={method.data}
          methods={availableMethods}
          eligibleForFreeShipping={
            stats?.freeShippingInfo.eligibleForFreeShipping
          }
          onSelected={(methodId) => method.self().update(methodId)}
          disabled={isBusy}
          isEditing={method.isEditing}
        />
        <FormEditNav
          isBusy={isBusy}
          isEditing={method.isEditing}
          isDirty={method.isDirty()}
          onCancel={method.cancel}
          onCommit={method.commit}
        />
      </div>
    </div>
  )
}
export default ShippingForm
