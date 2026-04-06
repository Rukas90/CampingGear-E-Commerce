import type { ReactNode } from "react"
import { twMerge } from "tailwind-merge"

interface IconButtonProps extends React.ComponentProps<"button"> {
  icon: ReactNode
}
const IconButton = ({ icon, className, ...props }: IconButtonProps) => {
  return (
    <button
      className={twMerge(
        "p-1 opacity-100 hover:opacity-80 active:opacity-60 transition-opacity cursor-pointer",
        className,
      )}
      {...props}
    >
      {icon}
    </button>
  )
}
export default IconButton
