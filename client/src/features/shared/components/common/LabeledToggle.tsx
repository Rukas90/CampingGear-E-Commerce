import clsx from "clsx"
import Toggle, { type ToggleProps } from "./Toggle"

interface LabeledToggleProps extends ToggleProps {
  label: string
}

const LabeledToggle = ({ label, ...props }: LabeledToggleProps) => {
  return (
    <div className="flex items-center mb-4 gap-2.5">
      <Toggle {...props} />
      <p
        className={clsx(
          "text-sm",
          props.disabled ? "text-neutral-500" : "text-neutral-800",
        )}
      >
        {label}
      </p>
    </div>
  )
}
export default LabeledToggle
