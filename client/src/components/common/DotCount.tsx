import { twMerge } from "tailwind-merge"

interface DotCountProps extends Omit<React.ComponentProps<"p">, "children"> {
  count?: number
}

const DotCount = ({ count = 1, className, ...props }: DotCountProps) => {
  return (
    <span
      {...props}
      className={twMerge(
        "absolute bg-black inter text-stone-200 text-[11px] font-semibold min-w-3.75 h-3.75 p-1 rounded-full flex items-center justify-center outline-2 outline-white -right-2 -top-2",
        className,
      )}
    >
      {count > 99 ? "99+" : count}
    </span>
  )
}
export default DotCount
