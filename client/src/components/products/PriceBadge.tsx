interface PriceBadgeProps {
  minPrice: number
  maxPrice: number
}
const PriceBadge = ({ minPrice, maxPrice }: PriceBadgeProps) => {
  const isRange = minPrice !== maxPrice

  const classes = "text-lime-800 text-sm font-semibold"

  if (!isRange) {
    return <p className={classes}>€{minPrice}</p>
  }
  return (
    <p className={classes}>
      €{minPrice} - €{maxPrice}
    </p>
  )
}
export default PriceBadge
