import { Line, OrderFinancialLine, PageWrapper } from "@components"
import { useOrder } from "@features"
import type { OrderId } from "@types"
import { formatDate, formatPrice } from "@utils"
import { Link, useParams } from "react-router-dom"

const OrderPage = () => {
  const { orderId } = useParams<{ orderId: OrderId }>()
  const { order } = useOrder(orderId)

  return (
    <PageWrapper className="w-full py-12">
      <title>Trailstore - Order</title>
      <Link to="/orders">
        <p className="mb-8 text-sm text-neutral-600">Back to orders</p>
      </Link>
      <div className="flex justify-between w-full items-center">
        <div>
          <p className="text-3xl font-semibold">Order</p>
          <p className="font-medium mt-1 text-sm text-neutral-600">
            # {order?.token}
          </p>
        </div>
        <div className="flex gap-12">
          <div>
            <p className="text-sm font-medium text-neutral-600 text-center">
              Status:
            </p>
            <p className="text-lg font-semibold mt-1">{order?.status}</p>
          </div>
          <div>
            <p className="text-sm font-medium text-neutral-600 text-right">
              Order Date:
            </p>
            <p className="text-lg font-semibold mt-1">
              {formatDate(order?.createdAt ?? "")}
            </p>
          </div>
        </div>
      </div>
      <Line className="mt-4 mb-8" />
      <div className="flex justify-between items-center">
        <p className="mb-4 font-semibold">Brought items:</p>
        <p className="mb-4 text-sm font-medium text-neutral-600">
          {order?.lineItems.length} total
        </p>
      </div>
      <table className="w-full">
        <thead>
          <tr className="border-b-2 border-stone-800 font-semibold text-xm">
            <th className="text-start py-1.5">Product</th>
            <th className="text-center py-1.5">Unit Price</th>
            <th className="text-center py-1.5">Quantity</th>
            <th className="text-right py-1.5">Total</th>
          </tr>
        </thead>
        <tbody>
          {order?.lineItems.map((item) => (
            <tr
              key={item.productName}
              className="border-b border-stone-200 text-xm"
            >
              <td className="py-4">
                <div className="flex items-center gap-2">
                  <img
                    className="mix-blend-darken w-14 mr-2"
                    src={item.thumbnailUrl}
                  />
                  <span>{item.productName}</span>
                  <span className="text-neutral-600">{item.variantLine}</span>
                </div>
              </td>
              <td className="py-4 text-center">
                {formatPrice(item.unitPrice)}
              </td>
              <td className="py-4 text-center">{item.quantity}</td>
              <td className="py-4 text-right">
                {formatPrice(item.unitPrice * item.quantity)}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <div className="mt-8">
        <p className="mb-4 font-semibold">Financials information:</p>
        <OrderFinancialLine
          label="Subtotal"
          price={order?.financials.subtotal}
        />
        <OrderFinancialLine
          label="Shipping"
          price={order?.financials.shippingCost}
        />
        <OrderFinancialLine label="Tax" price={order?.financials.tax} />
        <OrderFinancialLine
          label="Total"
          price={order?.financials.total}
          className="text-base font-semibold"
        />
      </div>
    </PageWrapper>
  )
}
export default OrderPage
