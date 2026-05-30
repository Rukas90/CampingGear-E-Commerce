import { twMerge } from "tailwind-merge"

const TextButton = ({
  className,
  children,
  ...props
}: React.ComponentProps<"button">) => {
  return (
    <button {...props}>
      <p
        className={twMerge(
          "text-sm text-accent hover:text-accent-dark active:text-black not-disabled:cursor-pointer underline not-disabled:hover:no-underline",
          className,
        )}
      >
        {children}
      </p>
    </button>
  )
}
export default TextButton
