export const formatPrice = (price?: number) => {
  return new Intl.NumberFormat("en-EU", {
    style: "currency",
    currency: "EUR",
  }).format(price ?? 0)
}
