import { IconArrow } from "@components"
import clsx from "clsx"
import { useEffect, useState } from "react"

interface ImageViewerCursorProps {
  containerRef: React.RefObject<HTMLDivElement | null>
  onPrev?: () => void
  onNext?: () => void
}
const ImageViewerCursor = ({
  containerRef,
  onPrev,
  onNext,
}: ImageViewerCursorProps) => {
  const [cursor, setCursor] = useState({
    x: 0,
    y: 0,
    visible: false,
    isLeft: false,
  })

  useEffect(() => {
    const elm = containerRef.current
    if (!elm) return

    const handleMouseMove = (e: MouseEvent) => {
      const rect = elm.getBoundingClientRect()

      const x = e.clientX - rect.left
      const y = e.clientY - rect.top

      setCursor({ x, y, visible: true, isLeft: x < rect.width / 2 })
    }

    const handleMouseLeave = () => setCursor((c) => ({ ...c, visible: false }))

    const handleClick = (e: MouseEvent) => {
      const rect = elm.getBoundingClientRect()
      const isLeft = e.clientX - rect.left < rect.width / 2

      isLeft ? onPrev?.() : onNext?.()
    }

    elm.addEventListener("mousemove", handleMouseMove)
    elm.addEventListener("mouseleave", handleMouseLeave)
    elm.addEventListener("click", handleClick)

    return () => {
      elm.removeEventListener("mousemove", handleMouseMove)
      elm.removeEventListener("mouseleave", handleMouseLeave)
      elm.removeEventListener("click", handleClick)
    }
  }, [containerRef.current, onPrev, onNext])

  if (!cursor.visible) return null

  return (
    <div
      className="pointer-events-none absolute flex justify-center items-center size-12 rounded-full bg-white shadow-md z-2"
      style={{
        left: cursor.x,
        top: cursor.y,
        translate: "-50% -50%",
      }}
    >
      <IconArrow
        className={clsx(
          "size-4 transition-transform duration-50",
          cursor.isLeft && "rotate-180",
        )}
        stroke="#000000"
        strokeWidth={0.5}
      />
    </div>
  )
}
export default ImageViewerCursor
