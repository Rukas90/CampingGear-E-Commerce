import { Spinner } from "@features"
import clsx from "clsx"
import { twMerge } from "tailwind-merge"

export type ButtonProps = React.ComponentProps<"button"> & {
  isLoading?: boolean
}

const BaseButton = ({
  isLoading,
  className,
  children,
  disabled,
  ...props
}: ButtonProps) => (
  <button
    className={twMerge(
      "rounded-lg py-4 cursor-pointer",
      className,
      "relative group",
    )}
    {...props}
    disabled={disabled || isLoading}
  >
    <div
      className={clsx(
        isLoading && "invisible",
        "flex justify-center items-center gap-2",
      )}
    >
      {children}
    </div>
    {isLoading && (
      <Spinner className="absolute size-4 top-1/2 left-1/2 -translate-1/2" />
    )}
  </button>
)
export default BaseButton
