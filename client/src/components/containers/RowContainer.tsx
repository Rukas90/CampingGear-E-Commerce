import { twMerge } from "tailwind-merge"

const RowContainer = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div className={twMerge(className, "flex flex-row")} {...props}>
      {children}
    </div>
  )
}

export default RowContainer
