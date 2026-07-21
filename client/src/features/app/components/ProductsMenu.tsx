import { PageWrapper, ProductCategoryListing } from "@features"
import clsx from "clsx"
import { twMerge } from "tailwind-merge"

interface ProductsMenuProps {
  show?: boolean
  className?: string
}
const ProductsMenu = ({ show, className }: ProductsMenuProps) => {
  return (
    <div
      className={twMerge(
        clsx(
          "absolute w-full left-0 bg-white translate-y-2 z-63 transition-all duration-200",
          show && "top-full opacity-100 pointer-events-auto",
          !show && "-top-full opacity-0 pointer-events-none",
        ),
        className,
      )}
    >
      <div className="w-full bg-neutral-200 h-0.5" />
      <PageWrapper className="py-4">
        <ProductCategoryListing />
      </PageWrapper>
      <div className="w-full bg-black h-0.5" />
    </div>
  )
}
export default ProductsMenu
