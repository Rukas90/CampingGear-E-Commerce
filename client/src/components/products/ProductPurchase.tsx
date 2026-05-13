import { useEffect, useState } from "react"
import ProductAddToCartQuantity from "./ProductAddToCartQuantity"
import ProductButtons from "./ProductButtons"
import ProductStockLabel from "./ProductStockLabel"
import { useProductView } from "@features"

const ProductPurchase = () => {
  const { sku } = useProductView()
  const [quantity, setQuantity] = useState(1)

  const stock = sku?.stock ?? 0

  useEffect(() => setQuantity(stock > 0 ? 1 : 0), [sku?.code])

  const handleAddToCart = () => {}

  const handleAddToWishlist = () => {}

  const handleQuantityChange = (newQuantity: number) => {
    newQuantity = Math.min(Math.max(newQuantity, 1), stock)
    setQuantity(newQuantity)
  }

  return (
    <>
      <ProductAddToCartQuantity
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
