import clsx from "clsx"
import type React from "react"

interface InputFieldProps extends Omit<
  React.ComponentProps<"input">,
  "children"
> {}
const InputField = ({ className, ...props }: InputFieldProps) => {
  return (
    <input
      className={clsx(
        className,
        "dark:bg-stone-900 bg-stone-50 px-3 py-2 text-sm rounded-sm border dark:border-stone-700 border-stone-200 hover:border-stone-400 dark:active:border-stone-600 dark:placeholder:text-stone-500 dark:text-stone-300",
      )}
      {...props}
    />
  )
}
export default InputField
