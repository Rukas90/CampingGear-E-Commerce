import { Line, IconX, IconTrash } from "@components"
import ProductAddToCartQuantity from "@components/common/AddToCartQuantity"
import { useCart, useCartSkuQuery } from "@features"
import type { CartEntry } from "@types"

const CartSidePanel = () => {
  const { items } = useCart()
  const { skus } = useCartSkuQuery(
    items.map((item) => item.code),
    {
      enabled: items.length > 0,
    },
  )

  const entries: CartEntry[] =
    skus?.map((sku) => ({
      ...sku,
      quantity: items.find((item) => item.code === sku.code)?.quantity ?? 0,
    })) ?? []

  const totalCartCost = entries.reduce(
    (sum, entry) => sum + entry.unitPrice * entry.quantity,
    0,
  )

  return (
    <div className="absolute top-0 left-0 bg-[#00000085] w-full h-full z-128">
      <div className="fixed h-full w-lg max-w-full right-0 top-0 p-4">
        <div className="flex flex-col justify-between bg-stone-100 w-full h-full rounded-lg py-8">
          <div id="cart-header" className="px-10">
            <div className="flex justify-between items-center">
              <div className="flex items-center gap-3">
                <p className="text-[1.65rem] font-medium tracking-normal">
                  Your Cart
                </p>
                <p className="flex bg-black rounded-full text-white size-5 items-center justify-center text-sm mb-4">
                  {items.length}
                </p>
              </div>
              <IconX className="size-3" strokeWidth="4.5" />
            </div>
            <Line className="my-4" />
          </div>
          <div
            id="cart-content"
            className="overflow-y-scroll overflow-x-hidden px-10"
          >
            {entries?.map((entry) => {
              const price = new Intl.NumberFormat("en-EU", {
                style: "currency",
                currency: "EUR",
              }).format(entry.unitPrice)

              return (
                <>
                  <div className="flex flex-col w-full py-4">
                    <div className="relative flex shine">
                      <div className="flex justify-center items-center bg-stone-200 p-2 rounded-lg">
                        <img
                          src={entry.thumbnailUrl}
                          className="mix-blend-darken size-22 shrink-0 object-contain"
                        />
                      </div>
                      <div className="flex flex-col justify-between pl-6 w-full">
                        <div className="flex">
                          <div>
                            <p className="text-sm">Brand name</p>
                            <p className="font-medium text-lg">
                              {entry.productName}
                            </p>
                            <div>
                              <p className="text-sm my-0.5">{price}</p>
                              <div className="my-1">
                                <p className="text-xs text-neutral-500">
                                  {entry.options
                                    .map(
                                      (option) =>
                                        `${option.groupName}: ${option.valueName}`,
                                    )
                                    .join(" · ")}
                                </p>
                              </div>
                            </div>
                            <div className="mt-1">
                              <ProductAddToCartQuantity
                                quantity={entry.quantity}
                                style="small"
                              />
                            </div>
                          </div>
                          <div className="ml-auto">
                            <IconTrash className="size-4.5 text-neutral-600" />
                          </div>
                        </div>
                        <div className="flex justify-between w-full mt-1">
                          <button className="text-sm underline hover:no-underline text-neutral-600 cursor-pointer">
                            Save for later
                          </button>
                          <p className="text-sm font-medium">Total: {price}</p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <Line />
                </>
              )
            })}
          </div>
          <div id="cart-footer" className="relative px-10">
            <Line className="absolute top-0 left-0 bg-neutral-200" />
            <div className="pb-6 pt-8 px-2">
              <div className="flex justify-between">
                <p className="text-2xl font-medium text-neutral-800">
                  Subtotal
                </p>
                <p className="text-2xl font-medium text-neutral-800">
                  €0.00 EUR
                </p>
              </div>
              <p className="mt-2 text-sm text-neutral-600">
                Free standard shipping on orders 99 EUR+
              </p>
            </div>

            <div className="flex gap-4">
              <button className="bg-[#e9e9e8] hover:bg-black text-black hover:text-white font-medium w-1/2 py-4 rounded-lg">
                View Cart
              </button>
              <button className="bg-black text-white font-medium w-1/2 py-4 rounded-lg">
                Checkout
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}
export default CartSidePanel
