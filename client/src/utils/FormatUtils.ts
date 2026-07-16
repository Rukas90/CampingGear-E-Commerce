export const formatPrice = (price?: number) => {
  return new Intl.NumberFormat("en-EU", {
    style: "currency",
    currency: "EUR",
  }).format(price ?? 0)
}

const dateFormatter = new Intl.DateTimeFormat("lt-LT", {
  year: "numeric",
  month: "short",
  day: "numeric",
})

export const formatDate = (value: string) => {
  const date = new Date(value)

  if (isNaN(date.getTime())) {
    return "—"
  }
  return dateFormatter.format(date)
}
