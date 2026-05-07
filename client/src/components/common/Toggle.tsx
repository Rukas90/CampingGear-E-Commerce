import clsx from "clsx"
import { useState, type CSSProperties } from "react"
import { twMerge } from "tailwind-merge"

interface ToggleProps {
  className?: (checked: boolean) => string
  knobClassName?: (checked: boolean) => string
  style?: CSSProperties
  knobStyle?: CSSProperties
  checked?: boolean
  onChange?: (checked: boolean) => void
}

const Toggle = ({
  className,
  knobClassName,
  style,
  knobStyle,
  checked,
  onChange,
}: ToggleProps) => {
  const [isChecked, setChecked] = useState(checked ?? false)

  const isControlled = checked !== undefined
  const effectiveChecked = isControlled ? checked : isChecked

  const handleChange = () => {
    if (!isControlled) {
      setChecked((current) => {
        const newState = !current
        onChange?.(newState)
        return newState
      })
      return
    }
    onChange?.(!checked)
  }

  return (
    <div
      role="checkbox"
      aria-checked={effectiveChecked}
      tabIndex={0}
      onClick={handleChange}
      onKeyDown={(e) => e.key === " " || (e.key === "Enter" && handleChange())}
      className={twMerge(
        clsx(
          "size-4 rounded-full border-2 shrink-0 cursor-pointer p-0.5 transition-colors duration-200",
          effectiveChecked ? "border-neutral-300" : "border-neutral-400",
        ),
        className?.(effectiveChecked),
      )}
      style={style}
    >
      <div
        className={twMerge(
          clsx(
            "size-full rounded-full transition-colors duration-200",
            effectiveChecked ? "bg-lime-800" : "bg-transparent",
          ),
          knobClassName?.(effectiveChecked),
        )}
        style={knobStyle}
      />
    </div>
  )
}
export default Toggle
