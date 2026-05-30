import clsx from "clsx"
import { twMerge } from "tailwind-merge"

interface LineProps extends Omit<React.ComponentProps<"div">, "children"> {
  vertical?: boolean
}

const Line = ({ vertical, className, ...props }: LineProps) => {
  return (
    <div
      className={twMerge(
        clsx(vertical && "w-px h-full", !vertical && "w-full h-px"),
        "bg-neutral-300",
        className,
      )}
      {...props}
    />
  )
}
export default Line
