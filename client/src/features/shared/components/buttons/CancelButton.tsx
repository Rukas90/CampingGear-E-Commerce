import { twMerge } from "tailwind-merge"
import BaseButton, { type ButtonProps } from "./BaseButton"

const CancelButton = ({ className, children, ...props }: ButtonProps) => (
  <BaseButton
    className={twMerge(
      "bg-neutral-100 text-neutral-800 disabled:bg-neutral-50 not-disabled:hover:bg-danger not-disabled:active:bg-neutral-800 transition-colors not-disabled:hover:text-white font-medium",
      className,
    )}
    {...props}
  >
    {children}
  </BaseButton>
)
export default CancelButton
