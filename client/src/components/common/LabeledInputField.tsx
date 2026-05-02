import { separateWords, upperFirstChar } from "@utils"
import InputField, { type InputFieldProps } from "./InputField"
import clsx from "clsx"

interface LabeledInputFieldProps extends InputFieldProps {
  parentClassName?: string
  error?: string
}
const LabeledInputField = ({
  error,
  parentClassName,
  name,
  ...props
}: LabeledInputFieldProps) => {
  return (
    <div className={clsx(parentClassName, "flex flex-col items-start")}>
      <label className="font-semibold text-sm mb-1.5 ml-0.5">
        {separateWords(upperFirstChar(name))}
      </label>
      <InputField name={name} {...props} indicateError={!!error} />
      {error && <p className="mt-1.5 text-red-800 text-sm pl-1.5">{error}</p>}
    </div>
  )
}
export default LabeledInputField
