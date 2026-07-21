import { twMerge } from "tailwind-merge"
import BaseButton, { type ButtonProps } from "./BaseButton"

const PopButton = ({ className, children, ...props }: ButtonProps) => (
  <BaseButton
    className={twMerge(
      "bg-neutral-100 disabled:bg-neutral-50 not-disabled:hover:bg-black not-disabled:active:bg-neutral-800 transition-colors not-disabled:hover:text-white font-medium",
      className,
    )}
    {...props}
  >
    {children}
  </BaseButton>
)
export default PopButton
