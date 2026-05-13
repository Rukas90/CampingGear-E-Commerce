import { Toggle } from "@components"
import { PreviewType, type FilterValue } from "@types"
import clsx from "clsx"
import { useSearchParams } from "react-router-dom"

interface FilterToggleProps extends FilterValue {
  filterKey: string
  selectionMode?: "append" | "replace"
  previewType?: PreviewType
  previewValue?: string
}

const FilterToggle = ({
  filterKey,
  selectionMode = "append",
  previewType,
  previewValue,
  name,
  slug,
  count,
}: FilterToggleProps) => {
  const [searchParams, setSearchParams] = useSearchParams()

  const selected =
    selectionMode === "append"
      ? searchParams.getAll(filterKey).includes(slug)
      : searchParams.get(filterKey) === slug

  const handleToggle = () => {
    setSearchParams((prev) => {
      if (selectionMode === "append") {
        if (selected) {
          prev.delete(filterKey, slug)
        } else {
          prev.append(filterKey, slug)
        }
      } else {
        if (selected) {
          prev.delete(filterKey)
        } else {
          prev.set(filterKey, slug)
        }
      }
      return prev
    })
  }

  const renderPrefix = () => {
    if (previewType === PreviewType.Color) {
      return (
        <Toggle
          checked={selected}
          className={(checked) => (checked ? "p-0.5" : "p-0 border-0 shadow")}
          knobStyle={{ backgroundColor: previewValue }}
        />
      )
    }
    if (previewType === PreviewType.Image) {
      return (
        <Toggle
          checked={selected}
          className={(checked) => (checked ? "p-0.5" : "p-0 border-0 shadow")}
          knobClassName={(_) => "bg-transparent"}
          knobStyle={{ backgroundImage: `url(${previewValue})` }}
        />
      )
    }
    return <Toggle checked={selected} />
  }

  const disabled = count <= 0

  return (
    <button
      onClick={handleToggle}
      className={clsx(
        "flex w-full pr-1.5 gap-2 items-center",
        disabled && "opacity-50",
      )}
      disabled={disabled}
    >
      {renderPrefix()}

      <div className="flex justify-between w-full">
        <p
          className={clsx(
            selected && "text-black",
            !selected && "text-neutral-600",
          )}
        >
          {name}
        </p>
        <p
          className={clsx(
            selected && "text-black",
            !selected && "text-neutral-600",
          )}
        >
          {count}
        </p>
      </div>
    </button>
  )
}
export default FilterToggle
