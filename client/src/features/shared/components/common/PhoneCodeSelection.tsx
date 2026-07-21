import { IconArrow, IconFlag, useCountries } from "@features"
import type { Country } from "@types"
import clsx from "clsx"
import {
  Button,
  ListBox,
  ListBoxItem,
  Popover,
  Select,
} from "react-aria-components"

interface PhoneCodeSelectionProps {
  selectedCountry?: Country
  onCodeSelected?: (code: string) => void
  disabled?: boolean
}
const PhoneCodeSelection = ({
  selectedCountry,
  onCodeSelected,
  disabled,
}: PhoneCodeSelectionProps) => {
  const { data } = useCountries()

  const handleCodeSelection = (code: string) => {
    onCodeSelected?.(code)
  }

  return (
    <Select
      aria-label="Phone country code"
      className="h-full"
      value={selectedCountry?.code ?? null}
      onChange={(key) => handleCodeSelection(key as string)}
      isDisabled={disabled}
    >
      <Button
        aria-label="Select phone country code"
        className="group flex justify-between items-center gap-1.5 px-3.5 rounded-lg h-full not-disabled:cursor-pointer"
        isDisabled={disabled}
      >
        {selectedCountry && (
          <div className="flex items-center gap-2">
            <IconFlag
              code={selectedCountry.code.toLowerCase()}
              className="scale-150 rounded-sm"
            />
            <p
              className={clsx(
                "text-sm",
                disabled && "text-neutral-500",
                !disabled && "text-neutral-800",
              )}
            >
              ({selectedCountry.phoneCode})
            </p>
          </div>
        )}
        <IconArrow
          className={clsx(
            "size-3 rotate-90 text-neutral-400",
            !disabled && "group-hover:text-neutral-900",
          )}
        />
      </Button>
      <Popover className="min-w-64 bg-white border border-neutral-200 rounded-lg shadow-lg overflow-auto max-h-60 overflow-y-auto">
        <ListBox items={data} className="outline-none">
          {data?.map((country) => (
            <ListBoxItem
              aria-label={country.name}
              key={country.code}
              id={country.code}
              textValue={country.name}
              className="px-3 py-2 text-sm cursor-pointer outline-none data-focused:bg-neutral-100"
              isDisabled={disabled}
            >
              <div className="flex items-center gap-2">
                <IconFlag
                  code={country.code.toLowerCase()}
                  className="rounded-sm size-6"
                />
                <span>{country.name}</span>
                <span className="text-neutral-400 ml-auto">
                  {country.phoneCode}
                </span>
              </div>
            </ListBoxItem>
          ))}
        </ListBox>
      </Popover>
    </Select>
  )
}
export default PhoneCodeSelection
