import clsx from "clsx"

const ProductCartButton = ({
  className,
  children,
  disabled,
  ...props
}: React.ComponentProps<"button">) => {
  return (
    <button
      className={clsx(
        "text-xl m-0 w-11 h-full border-2 border-neutral-200 rounded-l-md py-0.5 z-0",
        !disabled &&
          "hover:text-neutral-600 active:text-neutral-400 cursor-pointer",
        disabled && "text-neutral-400 cursor-not-allowed",
        className,
      )}
      disabled={disabled}
      {...props}
    >
      {children}
    </button>
  )
}
export default ProductCartButton
