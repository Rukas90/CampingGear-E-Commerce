import type { Stock } from "@types"
import clsx from "clsx"

const stockConfig: Record<
  Stock,
  { dot: string; text: string; ping: boolean; label: string }
> = {
  InStock: {
    dot: "bg-lime-600",
    text: "text-lime-800",
    ping: true,
    label: "In Stock",
  },
  LowStock: {
    dot: "bg-amber-500",
    text: "text-amber-500",
    ping: true,
    label: "Low Stock",
  },
  OutOfStock: {
    dot: "bg-red-500",
    text: "text-red-500",
    ping: false,
    label: "Out of Stock",
  },
}

interface ProductStockLabelProps {
  stock: number
}
const ProductStockLabel = ({ stock }: ProductStockLabelProps) => {
  const getStock = (): Stock => {
    if (stock <= 0) {
      return "OutOfStock"
    }
    if (stock <= 2) {
      return "LowStock"
    }
    return "InStock"
  }

  const { dot, text, ping, label } = stockConfig[getStock()]

  return (
    <div className="mt-4 flex items-center gap-3">
      <p
        className={clsx("size-1.5 rounded-full", ping && "animate-ping", dot)}
      />
      <p className={clsx("text-sm font-medium pb-0.5", text)}>{label}</p>
    </div>
  )
}
export default ProductStockLabel
