import { twMerge } from "tailwind-merge"

interface HorizontalLineLabelProps extends React.PropsWithChildren {
  className?: string
  lineClassName?: string
  labelClassName?: string
}

const HorizontalLineLabel = ({
  className,
  lineClassName,
  labelClassName,
  children,
}: HorizontalLineLabelProps) => {
  return (
    <div className={twMerge("flex gap-4 my-4 items-center", className)}>
      <div className={twMerge("w-full h-px bg-stone-200", lineClassName)} />
      <p
        className={twMerge(
          "text-center text-sm text-stone-600 font-medium shrink-0",
          labelClassName,
        )}
      >
        {children}
      </p>
      <div className={twMerge("w-full h-px bg-stone-200", lineClassName)} />
    </div>
  )
}
export default HorizontalLineLabel
