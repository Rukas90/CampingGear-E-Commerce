import { InputField } from "@components"
import { useCheckoutContact } from "@features"
import FormHeader from "./FormHeader"
import FormEditNav from "./FormEditNav"

const ContactForm = () => {
  const { data, section, isBusy } = useCheckoutContact()

  const emailAddress = data.value("emailAddress")

  return (
    <div>
      <FormHeader
        isLoading={isBusy}
        isEditing={section.isEditing}
        onEdit={section.edit}
      >
        Contact information
      </FormHeader>
      <InputField
        placeholder="Email"
        className="text-sm rounded-lg w-full bg-white"
        persistentLabel
        value={emailAddress.value()}
        onChange={(e) => emailAddress.update(e.currentTarget.value)}
        disabled={!section.isEditing || isBusy}
        error={emailAddress.error()}
      />
      <FormEditNav
        isBusy={isBusy}
        isEditing={section.isEditing}
        isDirty={data.isDirty()}
        onCancel={section.cancel}
        onCommit={data.commit}
      />
    </div>
  )
}
export default ContactForm
