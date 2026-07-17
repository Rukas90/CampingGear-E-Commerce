import type { ProblemDetails } from "@types"

export const hasError = (
  details: ProblemDetails,
  code: string | string[],
): boolean => {
  const codes = (Array.isArray(code) ? code : [code]).map((c) =>
    c.toLowerCase(),
  )
  return details.errors.some((err) => codes.includes(err.code.toLowerCase()))
}
