import { twMerge } from "tailwind-merge"

interface ProductOptionHeaderProps extends Omit<
  React.ComponentProps<"p">,
  "children"
> {
  name: string
  selectedOptionName: string
}

const ProductOptionHeader = ({
  name,
  selectedOptionName,
  className,
  ...props
}: ProductOptionHeaderProps) => {
  return (
    <p className={twMerge("text-lg text-neutral-500", className)} {...props}>
      <span>{name}: </span>
      <span className="text-neutral-800">{selectedOptionName}</span>
    </p>
  )
}
export default ProductOptionHeader
