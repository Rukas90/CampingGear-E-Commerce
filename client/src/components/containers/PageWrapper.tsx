import { twMerge } from "tailwind-merge"

const PageWrapper = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div
      className={twMerge(className, "relative max-w-6xl mx-auto px-6")}
      {...props}
    >
      {children}
    </div>
  )
}
export default PageWrapper
