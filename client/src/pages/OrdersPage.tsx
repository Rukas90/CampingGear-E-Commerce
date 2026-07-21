import { Spinner, useOrders } from "@features"
import { formatDate, formatPrice } from "@utils"
import { Link } from "react-router-dom"

const OrdersPage = () => {
  const { orders } = useOrders()

  if (!orders) {
    return <Spinner className="size-16 mx-auto" />
  }

  return (
    <table className="w-full">
      <title>Trailstore - Orders</title>
      <thead>
        <tr className="border-b-2 border-stone-800 font-semibold text-xm">
          <th className="text-start py-1.5">Order #</th>
          <th className="text-start py-1.5">Date</th>
          <th className="text-start py-1.5">Total</th>
          <th className="text-start py-1.5">Status</th>
          <th className="text-start py-1.5">Actions</th>
        </tr>
      </thead>
      <tbody>
        {orders.map((order) => (
          <tr key={order.id} className="border-b border-stone-200 text-xm">
            <td className="py-4 pr-4">{order.token}</td>
            <td className="py-4 pr-4">{formatDate(order.createdAt)}</td>
            <td className="py-4 pr-4">{formatPrice(order.total)}</td>
            <td className="py-4 pr-4 uppercase">{order.status}</td>
            <td className="py-4">
              <Link to={`/order/${order.id}`}>
                <button
                  type="button"
                  className="text-xs font-semibold tracking-wide underline underline-offset-2 hover:text-stone-600"
                >
                  View details
                </button>
              </Link>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}
export default OrdersPage
