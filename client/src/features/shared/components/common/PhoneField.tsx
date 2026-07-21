import { useCountries } from "@features"
import InputField, { type InputFieldProps } from "./InputField"
import PhoneCodeSelection from "./PhoneCodeSelection"
import { useEffect, useMemo, useState } from "react"
import parsePhoneNumber, {
  AsYouType,
  type CountryCode,
} from "libphonenumber-js/max"

interface PhoneFieldProps extends Omit<InputFieldProps, "type"> {
  countryCode?: string
}

const PhoneField = ({ countryCode, ...props }: PhoneFieldProps) => {
  const { data, findByCode } = useCountries()
  const [code, setCode] = useState<string>(countryCode ?? "LT")
  const [phoneValue, setPhoneValue] = useState<string>(
    (props.value as string) ?? "",
  )

  const [invalid, setInvalid] = useState(false)

  const selectedCountry = useMemo(() => {
    if (!data || !code) {
      return undefined
    }
    return findByCode(code)
  }, [data, code])

  useEffect(() => {
    setPhoneValue((props.value as string) ?? "")
  }, [props.value])

  useEffect(() => {
    if (!countryCode) {
      return
    }
    setCode(countryCode)
  }, [countryCode])

  useEffect(() => {
    if (!selectedCountry) return

    try {
      const parsed = parsePhoneNumber(
        phoneValue,
        selectedCountry.code as CountryCode,
      )
      if (parsed?.isValid()) return
    } catch {}

    const newValue = selectedCountry.phoneCode ?? ""
    setPhoneValue(newValue)
    props.onChange?.({ currentTarget: { value: newValue } } as any)
  }, [selectedCountry])

  const handleCountryChange = (newCode: string) => {
    setInvalid(false)
    setCode(newCode)
  }

  const handleNumberChange = (value: string) => {
    setInvalid(false)

    if (!value) {
      return selectedCountry?.phoneCode ?? ""
    }
    const formatted = new AsYouType(code as CountryCode).input(value)

    if (!data) {
      return formatted
    }

    if (value.startsWith("+")) {
      const matched = data.find((c) => value.startsWith(c.phoneCode))

      if (matched && matched.code !== code) {
        setCode(matched.code)
        return formatted
      }
    }

    try {
      const parsed = parsePhoneNumber(value, code as CountryCode)
      if (!parsed?.isValid()) {
        setInvalid(true)
      }
    } catch {}

    return formatted
  }

  return (
    <InputField
      {...props}
      value={phoneValue}
      type="tel"
      indicateError={invalid}
      onChange={(e) => {
        const formatted = handleNumberChange(e.currentTarget.value)
        setPhoneValue(formatted)

        e.currentTarget.value = formatted
        props.onChange?.(e)
      }}
      innerRender={
        <div className="absolute h-full right-0 top-0 group">
          <PhoneCodeSelection
            selectedCountry={selectedCountry}
            onCodeSelected={handleCountryChange}
            disabled={props.disabled}
          />
        </div>
      }
    />
  )
}

export default PhoneField
