import { twMerge } from "tailwind-merge"
import BaseButton, { type ButtonProps } from "./BaseButton"

const ContrastButton = ({ className, children, ...props }: ButtonProps) => (
  <BaseButton
    className={twMerge(
      "bg-black disabled:bg-neutral-700 not-disabled:hover:bg-neutral-900 not-disabled:active:bg-neutral-800 transition-colors text-white font-medium",
      className,
    )}
    {...props}
  >
    {children}
  </BaseButton>
)
export default ContrastButton
