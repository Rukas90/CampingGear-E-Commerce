import { InputField } from "@components"
import { useCheckoutContact } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"

const ContactForm = () => {
  const { data, isBusy } = useCheckoutContact()

  const emailAddress = data.value("emailAddress")

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        isEditing={data.isEditing}
        onEdit={data.edit}
      >
        Contact information
      </FormHeader>
      <InputField
        placeholder="Email"
        className="text-sm rounded-lg w-full bg-white"
        persistentLabel
        value={emailAddress.value()}
        onChange={(e) => emailAddress.update(e.currentTarget.value)}
        disabled={!data.isEditing || isBusy}
        error={emailAddress.error()}
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
export default ContactForm
