import { IconVisibilityOn } from "@components/img"
import clsx from "clsx"
import type React from "react"
import { useState } from "react"
import Eye from "./Eye"

export interface InputFieldProps extends Omit<
  React.ComponentProps<"input">,
  "children"
> {
  isHidden?: boolean
  isHideable?: boolean
  indicateError?: boolean
}
const InputField = ({
  isHidden,
  isHideable,
  indicateError,
  className,
  type,
  ...props
}: InputFieldProps) => {
  const [hidden, setHidden] = useState(isHidden)

  return (
    <div className="flex w-full">
      <input
        className={clsx(
          className,
          !indicateError && "border-stone-300 hover:border-stone-400",
          indicateError && "border-red-800 hover:border-red-700",
          isHideable ? "rounded-l-sm" : "rounded-sm",
          hidden && "font-serif",
          "bg-stone-50 px-3 py-2 border transition-colors",
        )}
        type={hidden ? "password" : type}
        {...props}
      />
      {isHideable && (
        <button
          type="button"
          onClick={() => setHidden((current) => !current)}
          className="bg-[#ebe9e8] hover:bg-stone-300 border-transparent hover:border-stone-300 border rounded-r-sm flex px-2 items-center transition-colors"
        >
          <Eye state={!hidden} className="size-5 text-neutral-800" />
        </button>
      )}
    </div>
  )
}
export default InputField
