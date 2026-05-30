import {
  CheckoutForm,
  CheckoutSummary,
  FooterBottom,
  Line,
  TopNav,
} from "@components"
import { useCheckout } from "@features"
import { useNavigate } from "react-router-dom"

const CheckoutPage = () => {
  const { data, isPending } = useCheckout()
  const navigate = useNavigate()

  if (isPending) {
    return
  }
  if (!isPending && !data) {
    navigate("/")
    return
  }

  return (
    <div className="flex flex-col w-full min-h-dvh">
      <TopNav className="relative" />
      <Line className="bg-neutral-200" />
      <div className="flex lg:flex-row flex-col flex-1">
        <div className="relative flex flex-col flex-1 basis-[54%] bg-white">
          <CheckoutForm />
          <Line vertical className="absolute top-0 right-0 text-neutral-200" />
        </div>
        <div className="flex flex-col flex-1 basis-[46%]">
          <CheckoutSummary />
        </div>
      </div>
      <FooterBottom />
    </div>
  )
}
export default CheckoutPage
