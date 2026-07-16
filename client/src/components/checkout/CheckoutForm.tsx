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
import { useAccount, useCheckoutContext } from "@features"
import { Link } from "react-router-dom"
import { useState } from "react"

const CheckoutForm = () => {
  const [saveInformation, setSaveInformation] = useState(true)
  const { isLoggedIn } = useAccount()
  const { confirm } = useCheckoutContext()

  return (
    <CheckoutSection className="flex gap-6 lg:ml-auto lg:mr-0 mx-auto">
      {!isLoggedIn && (
        <>
          <Link to="/login">
            <ContrastButton className="w-full text-sm py-3">
              Login
            </ContrastButton>
          </Link>
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
      {isLoggedIn && (
        <div className="flex gap-2.5">
          <Toggle
            onChange={(state) => setSaveInformation(state)}
            checked={saveInformation}
            defaultValue={saveInformation}
            className={(_) => "mt-0.5"}
          />
          <div className="text-start">
            <p className="text-sm text-accent">
              Save my information for a faster checkout
            </p>
            <p className="text-xs text-neutral-500 mt-1">
              By clicking the box, you agree to store checkout information to
              your current authenticated session.
              <br />
              <br />
              By choosing to opt out, your current checkout information will not
              be saved and any previously saved information will be erased.
            </p>
          </div>
        </div>
      )}
      <SubmitButton onClick={() => confirm(saveInformation)}>
        Place your Order
      </SubmitButton>
    </CheckoutSection>
  )
}
export default CheckoutForm
