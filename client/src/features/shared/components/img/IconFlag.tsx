import { twMerge } from "tailwind-merge"

interface IconFlagProps extends Omit<React.ComponentProps<"span">, "children"> {
  code: string
}
const IconFlag = ({ code, className, ...props }: IconFlagProps) => {
  return (
    <span
      className={twMerge(
        "w-4 h-3 rounded-lg",
        className,
        `fi fi-${code.toLocaleLowerCase()}`,
      )}
      {...props}
    />
  )
}
export default IconFlag
