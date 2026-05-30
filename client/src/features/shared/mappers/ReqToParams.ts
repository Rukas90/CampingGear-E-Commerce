import type { CustomMapper } from "./ParamMappers"

const reqToParams = (
  request: Record<string, unknown>,
  customMappers?: Partial<Record<string, CustomMapper>>,
): URLSearchParams => {
  const params = new URLSearchParams()

  Object.entries(request).forEach(([key, value]) => {
    if (value === undefined || value === null) return

    const customMapper = customMappers?.[key]
    if (customMapper) {
      customMapper(params, key, value)
      return
    }

    if (Array.isArray(value)) {
      value.forEach((v) => params.append(key, v.toString()))
    } else {
      params.append(key, value.toString())
    }
  })

  return params
}
export default reqToParams
