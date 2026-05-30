import { ContrastButton } from "@components"

const CheckoutFooter = () => {
  return (
    <>
      <ContrastButton className="mt-6">Place an order</ContrastButton>
      <p className="text-neutral-400 text-center text-xs mt-4">
        By pressing to place an order, all of the cart items will be used to
        make a new order, which will prompt to the final payment step.
        <br />
        <br />
        After placing an order no further cart changes can be made.
      </p>
    </>
  )
}
export default CheckoutFooter
