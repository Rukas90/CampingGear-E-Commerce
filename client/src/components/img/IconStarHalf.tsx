import * as React from "react"

const IconStarHalf = (props: React.SVGProps<SVGSVGElement>) => {
  const id = React.useId()
  return (
    <svg viewBox="0 0 24 24" fill="none" {...props}>
      <defs>
        <linearGradient id={`${id}-fill`}>
          <stop offset="50%" stopColor="#ffd280" />
          <stop offset="50%" stopColor="#e5e7eb" />
        </linearGradient>
        <linearGradient id={`${id}-stroke`}>
          <stop offset="50%" stopColor="#bd7b2d" />
          <stop offset="50%" stopColor="#9ca3af" />
        </linearGradient>
      </defs>
      <path
        d="m12 17.328-5.403 3.286a.75.75 0 0 1-1.12-.813l1.456-6.155-4.796-4.123a.75.75 0 0 1 .428-1.316l6.303-.517 2.44-5.835a.75.75 0 0 1 1.384 0l2.44 5.835 6.303.517a.75.75 0 0 1 .427 1.316l-4.795 4.123 1.456 6.155a.75.75 0 0 1-1.12.813L12 17.328z"
        fill={`url(#${id}-fill)`}
        stroke={`url(#${id}-stroke)`}
        strokeWidth="2px"
      />
    </svg>
  )
}

export default IconStarHalf
