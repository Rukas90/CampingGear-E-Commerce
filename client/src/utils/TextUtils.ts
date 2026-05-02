export const upperFirstChar = (value?: string) => {
  if (!value) {
    return value
  }
  return value.charAt(0).toUpperCase() + value.slice(1)
}

export const separateWords = (value?: string) => {
  if (!value) {
    return value
  }
  return value.replace(/([A-Z])/g, " $1").trim()
}
