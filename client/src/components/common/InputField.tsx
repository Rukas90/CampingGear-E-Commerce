import clsx from "clsx"
import type React from "react"
import { useState, type ReactNode } from "react"
import Eye from "./Eye"
import { twMerge } from "tailwind-merge"

export interface InputFieldProps extends Omit<
  React.ComponentProps<"input">,
  "children"
> {
  persistentLabel?: boolean
  isHidden?: boolean
  isHideable?: boolean
  indicateError?: boolean
  error?: string
  innerRender?: ReactNode
}
const InputField = ({
  persistentLabel,
  isHidden,
  isHideable,
  indicateError,
  error,
  className,
  type,
  placeholder,
  innerRender,
  ...props
}: InputFieldProps) => {
  const [text, setText] = useState(props.defaultValue ?? "")
  const [hidden, setHidden] = useState(isHidden)
  const [focus, setFocus] = useState(false)

  const isControlled = props.value !== undefined
  const value = isControlled ? (props.value ?? "") : text
  const showPlaceholder = !value
  const hasError = indicateError || !!error

  return (
    <div className="w-full">
      <div className="relative flex w-full">
        <div
          className={twMerge(
            clsx(
              !hasError && "border-stone-300 hover:border-stone-400",
              isHideable ? "rounded-l-lg" : "rounded-lg",
              hidden && "font-serif",
              "bg w-full border text-sm transition-colors",
              focus &&
                !hasError &&
                "outline-2 outline-black border-transparent",
              hasError && "outline-2 outline-red-700 border-transparent",
            ),
            className,
            "relative",
          )}
        >
          <input
            {...props}
            className={clsx(
              "peer outline-0 w-full px-3 transition-[padding] duration-75 disabled:text-neutral-500",
              !persistentLabel && "py-2",
              persistentLabel && !showPlaceholder && "pb-1.5 pt-6",
              persistentLabel && showPlaceholder && "py-3.75",
            )}
            type={hidden ? "password" : type}
            placeholder={!persistentLabel ? placeholder : undefined}
            onFocus={(e) => {
              setFocus(true)
              props.onFocus?.(e)
            }}
            onBlur={(e) => {
              setFocus(false)
              props.onBlur?.(e)
            }}
            onChange={(e) => {
              const newValue = e.currentTarget.value

              if (!isControlled) {
                setText(newValue)
              }
              props.onChange?.(e)
            }}
            value={value}
          />
          {persistentLabel && (
            <p
              className={clsx(
                "absolute left-3 transition-[font-size, top, transform] will-change-transform duration-75 text-neutral-500 peer-disabled:text-neutral-400 pointer-events-none",
                !showPlaceholder && "text-xs top-2",
                showPlaceholder && "text-sm top-1/2 -translate-y-1/2",
              )}
            >
              {placeholder}
            </p>
          )}
        </div>

        {isHideable && (
          <button
            type="button"
            onClick={() => setHidden((current) => !current)}
            className="bg-[#ebe9e8] hover:bg-stone-300 border-transparent hover:border-stone-300 border rounded-r-sm flex px-2 items-center transition-colors"
          >
            <Eye state={!hidden} className="size-5 text-neutral-800" />
          </button>
        )}
        {innerRender}
      </div>
      {!!error && <p className="text-red-800 text-xs mt-2">{error}</p>}
    </div>
  )
}

export default InputField
