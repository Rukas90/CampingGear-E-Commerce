import { IconPlus } from "@components"
import clsx from "clsx"
import { useState } from "react"

interface FoldoutContentProps extends React.ComponentProps<"div"> {
  label: string
  opened?: boolean
}
const FoldoutContent = ({
  label,
  opened,
  children,
  className,
}: FoldoutContentProps) => {
  const [isOpened, setOpened] = useState(opened)

  return (
    <div className={clsx("flex flex-col", className)}>
      <button
        onClick={() => setOpened((current) => !current)}
        className="flex w-full justify-between items-center"
      >
        <p className="text-[1.085rem] font-medium">{label}</p>
        <IconPlus
          className={clsx(
            "text-neutral-800 size-5 transition-transform duration-300",
            isOpened && "rotate-45",
          )}
        />
      </button>
      <div
        className={clsx(
          "grid transition-[grid-template-rows, margin] duration-300",
          isOpened ? "grid-rows-[1fr] mt-2" : "grid-rows-[0fr] mt-0",
        )}
      >
        <div className="overflow-hidden">{children}</div>
      </div>
    </div>
  )
}

export default FoldoutContent
