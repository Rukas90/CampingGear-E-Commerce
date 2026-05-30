export type CustomMapper = (
  params: URLSearchParams,
  key: string,
  value: unknown,
) => void

export const recordMapper: CustomMapper = (params, key, value) => {
  Object.entries(value as Record<string, string>).forEach(([k, v]) => {
    params.append(`${key}[${k}]`, v)
  })
}
