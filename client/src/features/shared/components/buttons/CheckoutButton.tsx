import ContrastButton from "./ContrastButton"

const CheckoutButton = ({
  children,
  ...props
}: React.ComponentProps<"button">) => (
  <ContrastButton {...props}>
    <div className="flex items-center gap-1">{children} Checkout</div>
  </ContrastButton>
)
export default CheckoutButton
