import { twMerge } from "tailwind-merge"

const PageWrapper = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div
      className={twMerge("relative max-w-7xl mx-auto px-6", className)}
      {...props}
    >
      {children}
    </div>
  )
}
export default PageWrapper
