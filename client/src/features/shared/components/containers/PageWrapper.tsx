import { twMerge } from "tailwind-merge"

const PageWrapper = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div
      className={twMerge(
        "relative max-w-7xl mr-auto ml-auto sm:px-6 px-4",
        className,
      )}
      {...props}
    >
      {children}
    </div>
  )
}
export default PageWrapper
