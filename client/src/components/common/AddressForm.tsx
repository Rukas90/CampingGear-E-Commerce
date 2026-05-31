import {
  CountrySelection,
  InputField,
  PhoneField,
  RowContainer,
} from "@components"
import { useCountries, type FieldInterface } from "@features"
import { PostalCodeRequirement, type PostalAddress } from "@types"
import { useMemo } from "react"
import { twMerge } from "tailwind-merge"

interface AddressFormProps<T extends React.ElementType = "div"> {
  as?: T
  field: AddressField
  className?: string
  disabled?: boolean
}

export type AddressField = FieldInterface<PostalAddress>

const AddressForm = <T extends React.ElementType = "div">({
  as,
  field,
  className,
  disabled,
}: AddressFormProps<T>) => {
  const { findByCode, dataUpdatedAt } = useCountries()
  const Component = as ?? "div"

  const countryCode = field.value("countryCode")
  const country = useMemo(
    () => findByCode(countryCode),
    [dataUpdatedAt, countryCode],
  )

  return (
    <Component className={twMerge(className, "flex flex-col gap-4")}>
      <CountrySelection
        selectedCode={countryCode}
        error={field.error("countryCode")}
        onChange={(c) => field.update("countryCode", c.code)}
        disabled={disabled}
      />
      <RowContainer className="gap-4">
        <InputField
          placeholder="First name"
          persistentLabel
          value={field.value("recipientFirstName")}
          error={field.error("recipientFirstName")}
          onChange={(e) =>
            field.update("recipientFirstName", e.currentTarget.value)
          }
          disabled={disabled}
        />
        <InputField
          placeholder="Last name"
          persistentLabel
          value={field.value("recipientLastName")}
          error={field.error("recipientLastName")}
          onChange={(e) =>
            field.update("recipientLastName", e.currentTarget.value)
          }
          disabled={disabled}
        />
      </RowContainer>
      <InputField
        placeholder="Company (optional)"
        persistentLabel
        value={field.value("company")}
        error={field.error("company")}
        onChange={(e) => field.update("company", e.currentTarget.value)}
        disabled={disabled}
      />
      <InputField
        placeholder="Address"
        persistentLabel
        value={field.value("addressLine")}
        error={field.error("addressLine")}
        onChange={(e) => field.update("addressLine", e.currentTarget.value)}
        disabled={disabled}
      />
      <InputField
        placeholder="Apartment, suite, etc. (optional)"
        persistentLabel
        value={field.value("apartmentSuite")}
        error={field.error("apartmentSuite")}
        onChange={(e) => field.update("apartmentSuite", e.currentTarget.value)}
        disabled={disabled}
      />
      <RowContainer className="gap-4 w-full">
        <InputField
          placeholder="City"
          persistentLabel
          value={field.value("city")}
          error={field.error("city")}
          onChange={(e) => field.update("city", e.currentTarget.value)}
          disabled={disabled}
        />
        {country?.hasRegion && (
          <InputField
            key={country.regionLabel}
            placeholder={country.regionLabel}
            persistentLabel
            value={field.value("region")}
            error={field.error("region")}
            onChange={(e) => field.update("region", e.currentTarget.value)}
            disabled={disabled}
          />
        )}
        {country && country.postalCode !== PostalCodeRequirement.None && (
          <InputField
            key={country?.postalCodeLabel ?? ""}
            placeholder={country?.postalCodeLabel}
            persistentLabel
            value={field.value("postalCode")}
            error={field.error("postalCode")}
            onChange={(e) => field.update("postalCode", e.currentTarget.value)}
            disabled={disabled}
          />
        )}
      </RowContainer>
      <PhoneField
        placeholder="Phone"
        persistentLabel
        countryCode={countryCode}
        value={field.value("phoneNumber")}
        error={field.error("phoneNumber")}
        onChange={(e) => field.update("phoneNumber", e.currentTarget.value)}
        disabled={disabled}
      />
    </Component>
  )
}

export default AddressForm
