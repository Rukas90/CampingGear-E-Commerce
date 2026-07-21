import clsx from "clsx"

const FilterContent = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div className={clsx("flex flex-col gap-1", className)} {...props}>
      {children}
    </div>
  )
}
export default FilterContent
