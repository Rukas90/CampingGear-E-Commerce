import { IconArrow, IconFlag } from "@components"
import { useCountries } from "@features"
import type { Country } from "@types"
import clsx from "clsx"
import {
  Select,
  SelectValue,
  Button,
  Popover,
  ListBox,
  ListBoxItem,
  Label,
} from "react-aria-components"

interface CountrySelectionProps {
  selectedCode?: string
  error?: string
  onChange?: (country: Country) => void
  disabled?: boolean
}
const CountrySelection = ({
  selectedCode,
  error,
  onChange,
  disabled,
}: CountrySelectionProps) => {
  const { data, findByCode } = useCountries()
  const hasError = !!error

  return (
    <Select
      aria-label="Country"
      value={selectedCode ?? null}
      onChange={(key) => {
        const country = findByCode(key?.toString())
        if (country) onChange?.(country)
      }}
      className="group relative flex flex-col"
      isDisabled={disabled}
    >
      <Button
        className={clsx(
          "group relative flex flex-col items-start px-3 py-2 w-full rounded-lg border",
          hasError && "outline-2 outline-red-700 border-transparent",
          !hasError && "border-neutral-300",
        )}
        isDisabled={disabled}
      >
        <Label className="text-xs text-neutral-500 group-disabled:text-neutral-400">
          Country
        </Label>
        <div>
          <SelectValue className="flex gap-1.5 items-center text-sm flex-1 text-left mt-0.5 group-disabled:text-neutral-600" />
        </div>
        <IconArrow className="absolute top-1/2 -translate-y-1/2 right-4 size-4 rotate-90 text-neutral-400" />
      </Button>
      <Popover className="w-(--trigger-width) bg-white border border-neutral-200 rounded-lg shadow-lg overflow-auto max-h-60 overflow-y-auto">
        <ListBox items={data} className="outline-none">
          {data?.map((country) => (
            <ListBoxItem
              key={country.code}
              id={country.code}
              textValue={country.name}
              className="flex gap-2 items-center px-3 py-2 text-sm rounded cursor-pointer outline-none data-focused:bg-neutral-100"
              isDisabled={disabled}
            >
              <IconFlag code={country.code} className="scale-125 rounded-sm" />
              <p className="group-disabled:text-neutral-600">{country.name}</p>
            </ListBoxItem>
          ))}
        </ListBox>
      </Popover>
      {hasError && <p className="text-red-800 text-xs mt-2">{error}</p>}
    </Select>
  )
}
export default CountrySelection
