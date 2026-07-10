import {
  MessageBox,
  PageWrapper,
  OutlineButton,
  IconArrow,
  Line,
} from "@components"
import { useOrder } from "@features"
import type { OrderId } from "@types"
import { useParams } from "react-router-dom"

const OrderCanceledPage = () => {
  const { orderId } = useParams<{ orderId: OrderId }>()
  const { data, isPending } = useOrder(orderId)

  if (isPending) {
    return
  }

  return (
    <PageWrapper className="w-full flex gap-16 py-24">
      <div className="basis-1/2 flex flex-col gap-4">
        <p className="text-lg font-semibold">ORDER HAS BEEN CANCELED</p>
        <Line className="bg-neutral-200" />
        <MessageBox variant="error">
          <span>Your order is being processed</span>
        </MessageBox>
        <p className="text-sm text-neutral-700">
          <span className="font-semibold">Order:</span> #{data?.token}
        </p>
        <p className="text-sm text-neutral-700">
          Your order has been cancelled. You'll receive a confirmation email at{" "}
          <span className="font-semibold">{data?.emailAddress}</span> shortly.
        </p>
        <a href="/">
          <OutlineButton className="self-start px-4 py-3 text-sm">
            Go to homepage
            <IconArrow className="size-4 group-hover:translate-x-1 transition-transform" />
          </OutlineButton>
        </a>
      </div>
    </PageWrapper>
  )
}
export default OrderCanceledPage
