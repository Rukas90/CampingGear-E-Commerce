import { twMerge } from "tailwind-merge"
import BaseButton, { type ButtonProps } from "./BaseButton"

const OutlineButton = ({ className, children, ...props }: ButtonProps) => (
  <BaseButton
    className={twMerge(
      "border-black border-2 disabled:border-neutral-700 not-disabled:hover:border-neutral-800 not-disabled:active:border-neutral-600 transition-colors text-black font-medium",
      className,
    )}
    {...props}
  >
    {children}
  </BaseButton>
)
export default OutlineButton
