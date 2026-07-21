import { CustomPointer, IconArrow, type CursorData } from "@features"
import clsx from "clsx"
import { useCallback } from "react"

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
  const handleClick = useCallback(
    (data: CursorData) => (data.isLeft ? onPrev?.() : onNext?.()),
    [onPrev, onNext],
  )
  return (
    <CustomPointer
      className="size-12 rounded-full bg-white shadow-md z-2"
      containerRef={containerRef}
      onClick={handleClick}
      innerRender={(data) => (
        <IconArrow
          className={clsx(
            "size-4 transition-transform duration-50",
            data.isLeft && "rotate-180",
          )}
          stroke="#000000"
          strokeWidth={0.5}
        />
      )}
    />
  )
}
export default ImageViewerCursor
