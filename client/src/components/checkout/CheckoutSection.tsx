import { twMerge } from "tailwind-merge"

const CheckoutSection = ({
  className,
  children,
}: React.ComponentProps<"div">) => {
  return (
    <div
      className={twMerge(
        "lg:w-lg w-full lg:min-w-lg max-w-full flex flex-col p-8",
        className,
      )}
    >
      {children}
    </div>
  )
}
export default CheckoutSection
