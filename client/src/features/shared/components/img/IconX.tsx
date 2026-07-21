import * as React from "react"

const IconX = ({
  strokeWidth = 1.5,
  ...props
}: React.SVGProps<SVGSVGElement>) => {
  return (
    <svg viewBox="2.25 2.57 19.5 19.5" fill="none" {...props}>
      <path
        d="M3 21.32L21 3.32001"
        stroke="currentColor"
        strokeWidth={strokeWidth}
        strokeLinecap="round"
        strokeLinejoin="round"
      />
      <path
        d="M3 3.32001L21 21.32"
        stroke="currentColor"
        strokeWidth={strokeWidth}
        strokeLinecap="round"
        strokeLinejoin="round"
      />
    </svg>
  )
}

export default IconX
