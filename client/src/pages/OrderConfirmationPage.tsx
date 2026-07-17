import {
  IconSuccess,
  MessageBox,
  PageWrapper,
  OutlineButton,
  IconArrow,
  DotCount,
  CostLabel,
  OrderFinancialsStats,
  Line,
} from "@components"
import { useOrder } from "@features"
import type { OrderId } from "@types"
import { useParams } from "react-router-dom"

const OrderConfirmationPage = () => {
  const { orderId } = useParams<{ orderId: OrderId }>()
  const { data, isPending } = useOrder(orderId)

  if (isPending) {
    return
  }

  return (
    <PageWrapper className="w-full flex gap-16 py-24">
      <title>Trailstore - Order Confirmation</title>
      <div className="basis-2/3 flex flex-col gap-4">
        <p className="text-xl font-medium">THANK YOU FOR YOUR ORDER!</p>
        <Line className="bg-neutral-200" />
        <MessageBox>
          <IconSuccess className="text-accent size-5" />
          <span>Your order is being processed</span>
        </MessageBox>
        <p className="text-sm text-neutral-700">
          <span className="font-semibold">Order:</span> #{data?.token}
        </p>
        <p className="text-sm text-neutral-700">
          You'll receive a confirmation email at{" "}
          <span className="font-semibold">{data?.emailAddress}</span> shortly.
          The order will appear in your account as soon as you've received the
          email.
        </p>
        <a href="/">
          <OutlineButton className="self-start px-4 py-3 text-sm">
            Go to homepage
            <IconArrow className="size-4 group-hover:translate-x-1 transition-transform" />
          </OutlineButton>
        </a>
        <p className="text-sm text-neutral-700">
          Want to cancel? You can do this up to one hour after receiving your
          confirmation email.
        </p>
      </div>
      <div className="basis-2/5 flex flex-col gap-4">
        <p className="flex justify-between items-center">
          <span className="text-xl font-medium">BROUGHT ITEMS</span>
          <span className="text-xm text-neutral-600">
            {data?.lineItems.length} item
          </span>
        </p>
        <Line className="bg-neutral-200" />
        {data?.lineItems.map((item) => (
          <div className="flex">
            <div className="relative flex w-16 min-h-16 p-0.5 rounded-lg mb-2 bg-white drop-shadow-sm drop-shadow-neutral-200">
              <div className="flex border border-neutral-200 w-full h-full p-0.5 rounded-lg shine">
                <img
                  className="object-contain mix-blend-darken w-16 aspect-square mx-auto"
                  src={item.thumbnailUrl}
                />
              </div>
              <DotCount
                count={item.quantity}
                className="-top-0.5 -right-1 text-[12px] font-normal text-white max-w-5.25 min-w-5.25 h-5.25"
              />
            </div>
            <div className="flex gap-0.5 flex-col py-3 pl-3 w-full">
              <div className="flex justify-between w-full">
                <p className="text-xs text-accent">{item.brandName}</p>
                <CostLabel
                  className="ml-auto text-xs font-medium"
                  cost={item.unitPrice * item.quantity}
                />
              </div>
              <p className="text-[0.8rem]">{item.productName}</p>
              <p className="text-xs text-neutral-500">{item.variantLine}</p>
            </div>
          </div>
        ))}
        <OrderFinancialsStats financials={data?.financials} />
      </div>
    </PageWrapper>
  )
}
export default OrderConfirmationPage
