import clsx from "clsx"

const IconDiagonalLine = ({
  className,
  ...props
}: React.SVGProps<SVGSVGElement>) => {
  return (
    <svg
      className={clsx("absolute inset-0 w-full h-full", className)}
      {...props}
      preserveAspectRatio="none"
    >
      <line
        x1="0"
        y1="0"
        x2="100%"
        y2="100%"
        stroke="currentColor"
        strokeWidth="1"
      />
    </svg>
  )
}
export default IconDiagonalLine
