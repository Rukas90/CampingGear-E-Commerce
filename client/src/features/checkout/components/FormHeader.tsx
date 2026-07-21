import { Spinner, TextButton } from "@features"
import { twMerge } from "tailwind-merge"

interface FormHeaderProps extends React.ComponentProps<"p"> {
  isLoading?: boolean
  isEditing?: boolean
  onEdit?: () => void
}

const FormHeader = ({
  isLoading,
  isEditing,
  onEdit,
  className,
  children,
  ...props
}: FormHeaderProps) => {
  return (
    <div className="flex mb-3 items-center justify-between">
      <div className="flex gap-3 items-center">
        <p
          className={twMerge(
            "text-xl pl-0.5 font-medium text-neutral-800",
            className,
          )}
          {...props}
        >
          {children}
        </p>
        {isLoading && <Spinner className="size-4" />}
      </div>
      {!isEditing && <TextButton onClick={onEdit}>Edit</TextButton>}
    </div>
  )
}
export default FormHeader
