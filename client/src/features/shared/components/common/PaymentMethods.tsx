import {
  CardDiscover,
  CardGooglePay,
  CardMastercard,
  CardPaypal,
  CardVisa,
} from "@features"
import { twMerge } from "tailwind-merge"

interface PaymentMethodsProps extends Omit<
  React.ComponentProps<"div">,
  "children"
> {
  cardClassName?: string
}
const PaymentMethods = ({
  cardClassName,
  className,
  ...props
}: PaymentMethodsProps) => {
  const defaultCardClasses = "h-5 rounded-sm"

  return (
    <div className={twMerge("flex gap-2", className)} {...props}>
      <CardMastercard className={twMerge(defaultCardClasses, cardClassName)} />
      <CardVisa className={twMerge(defaultCardClasses, cardClassName)} />
      <CardPaypal className={twMerge(defaultCardClasses, cardClassName)} />
      <CardDiscover className={twMerge(defaultCardClasses, cardClassName)} />
      <CardGooglePay className={twMerge(defaultCardClasses, cardClassName)} />
    </div>
  )
}
export default PaymentMethods
