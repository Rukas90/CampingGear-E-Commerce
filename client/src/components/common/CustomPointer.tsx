import { useEffect, useState, type ReactNode } from "react"
import { twMerge } from "tailwind-merge"

export type CursorData = {
  x: number
  y: number
  visible: boolean
  isLeft: boolean
}

export interface CustomPointerProps extends Omit<
  React.ComponentProps<"div">,
  "style" | "onClick" | "children"
> {
  containerRef: React.RefObject<HTMLDivElement | null>
  innerRender?: (data: CursorData) => ReactNode
  onClick?: (data: CursorData) => void
}

const CustomPointer = ({
  containerRef,
  innerRender,
  className,
  onClick,
}: CustomPointerProps) => {
  const [cursor, setCursor] = useState({
    x: 0,
    y: 0,
    visible: false,
    isLeft: false,
  })

  useEffect(() => {
    const elm = containerRef.current

    if (!elm) {
      return
    }
    const handleMouseMove = (e: MouseEvent) => {
      setCursor(getCursorData(e))
    }

    const handleMouseLeave = () => setCursor((c) => ({ ...c, visible: false }))

    const handleClick = (e: MouseEvent) => {
      onClick?.(getCursorData(e))
    }

    const getCursorData = (e: MouseEvent): CursorData => {
      const rect = elm.getBoundingClientRect()

      const x = e.clientX - rect.left
      const y = e.clientY - rect.top

      return {
        x,
        y,
        visible: true,
        isLeft: x < rect.width / 2,
      }
    }

    elm.addEventListener("mousemove", handleMouseMove)
    elm.addEventListener("mouseleave", handleMouseLeave)
    elm.addEventListener("click", handleClick)

    return () => {
      elm.removeEventListener("mousemove", handleMouseMove)
      elm.removeEventListener("mouseleave", handleMouseLeave)
      elm.removeEventListener("click", handleClick)
    }
  }, [containerRef.current, onClick])

  if (!cursor.visible) {
    return null
  }

  return (
    <div
      className={twMerge(
        "flex justify-center items-center",
        className,
        "pointer-events-none absolute",
      )}
      style={{
        left: cursor.x,
        top: cursor.y,
        translate: "-50% -50%",
      }}
    >
      {innerRender?.(cursor)}
    </div>
  )
}
export default CustomPointer
