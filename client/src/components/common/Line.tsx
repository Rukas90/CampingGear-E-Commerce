import { twMerge } from "tailwind-merge"

interface LineProps extends Omit<React.ComponentProps<"div">, "children"> {}

const Line = ({ className, ...props }: LineProps) => {
  return (
    <div
      className={twMerge("w-full h-px bg-neutral-300", className)}
      {...props}
    />
  )
}
export default Line
