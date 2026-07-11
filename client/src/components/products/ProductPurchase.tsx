import { useEffect, useState } from "react"
import ProductButtons from "./ProductButtons"
import ProductStockLabel from "./ProductStockLabel"
import { useCartContext, useProductView } from "@features"
import { AddToCartQuantity } from "@components"

const ProductPurchase = () => {
  const { sku } = useProductView()
  const [quantity, setQuantity] = useState(1)
  const { addItem } = useCartContext()

  const stock = sku?.stock ?? 0

  useEffect(() => setQuantity(stock > 0 ? 1 : 0), [sku?.code])

  const handleAddToCart = () => {
    if (!sku) {
      return
    }
    addItem(sku.id, quantity)
  }

  const handleAddToWishlist = () => {}

  const handleQuantityChange = (newQuantity: number) => {
    newQuantity = Math.min(Math.max(newQuantity, 1), stock)
    setQuantity(newQuantity)
  }

  return (
    <>
      <AddToCartQuantity
        quantity={quantity}
        onQuantityChanged={handleQuantityChange}
        disabled={stock <= 0}
      />
      <ProductStockLabel stock={stock} />
      <ProductButtons
        stock={stock}
        unitPrice={sku?.unitPrice ?? 0}
        quantity={quantity}
        onAddToCart={handleAddToCart}
        onAddToWishlist={handleAddToWishlist}
      />
    </>
  )
}
export default ProductPurchase
