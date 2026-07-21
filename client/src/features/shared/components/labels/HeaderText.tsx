import clsx from "clsx"

const HeaderText = ({
  children,
  className,
  ...props
}: React.ComponentProps<"p">) => {
  return (
    <p
      className={clsx(
        "text-3xl font-bold tracking-wide text-stone-800 inter",
        className,
      )}
      {...props}
    >
      {children}
    </p>
  )
}
export default HeaderText
