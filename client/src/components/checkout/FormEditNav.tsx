import { SubmitButton, PopButton } from "@components"
import clsx from "clsx"

interface FormEditNavProps {
  isEditing?: boolean
  isBusy?: boolean
  isDirty?: boolean
  onCommit: () => void
  onCancel: () => void
}
const FormEditNav = ({
  isEditing,
  isBusy,
  isDirty,
  onCommit,
  onCancel,
}: FormEditNavProps) => {
  return (
    <div className={clsx(!isEditing && "hidden")}>
      <div className="flex gap-3 mt-4">
        <PopButton
          className="text-sm py-2 basis-1/2"
          onClick={onCancel}
          isLoading={isBusy}
        >
          Cancel
        </PopButton>
        <SubmitButton
          className="text-sm py-2 basis-1/2"
          onClick={onCommit}
          isLoading={isBusy}
          disabled={!isDirty}
        >
          Save
        </SubmitButton>
      </div>
    </div>
  )
}
export default FormEditNav
