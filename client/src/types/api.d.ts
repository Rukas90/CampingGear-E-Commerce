export type ApiResult<T> = {
  isSuccess: boolean
  data?: T
  error?: ProblemDetails
}

export type ProblemDetailsError = {
  name: string
  code: string
  reason: string
}

export type ProblemDetails = {
  type: string
  title: string
  instance?: string
  traceId?: string
  status: number
  detail?: string
  errors: ProblemDetailsError[]
}

export type RequestMethod = "get" | "post" | "put" | "delete"
