import ShippingForm from "./ShippingForm"
import BillingForm from "./BillingForm"
import ContactForm from "./ContactForm"
import CheckoutSection from "./CheckoutSection"
import {
  ContrastButton,
  HorizontalLineLabel,
  Line,
  SubmitButton,
  Toggle,
} from "@components"
import { useAccount } from "@features"

const CheckoutForm = () => {
  const { isLoggedIn } = useAccount()

  return (
    <CheckoutSection className="flex gap-6 lg:ml-auto lg:mr-0 mx-auto">
      {!isLoggedIn && (
        <>
          <ContrastButton className="w-full text-sm py-3">Login</ContrastButton>
          <HorizontalLineLabel
            className="my-0"
            labelClassName="text-neutral-500 font-normal"
          >
            OR
          </HorizontalLineLabel>
        </>
      )}
      <div className="flex flex-col gap-9">
        <ContactForm />
        <ShippingForm />
        <BillingForm />
      </div>
      <Line className="text-neutral-200" />
      <div className="flex gap-2.5">
        <Toggle className={(_) => "mt-0.5"} />
        <div className="text-start">
          <p className="text-sm text-accent">
            Save my information for a faster checkout
          </p>
          <p className="text-xs text-neutral-500 mt-1">
            By clicking the box, you agree to store checkout information to your
            current shopping session.
          </p>
        </div>
      </div>
      <SubmitButton>Proceed to Payment</SubmitButton>
    </CheckoutSection>
  )
}
export default CheckoutForm
