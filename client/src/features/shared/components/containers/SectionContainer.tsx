import { twMerge } from "tailwind-merge"

const SectionContainer = ({
  className,
  children,
  ...props
}: React.ComponentProps<"div">) => {
  return (
    <div className={twMerge("my-8", className)} {...props}>
      {children}
    </div>
  )
}
export default SectionContainer
