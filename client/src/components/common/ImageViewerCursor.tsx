import { CustomPointer, IconArrow } from "@components"
import clsx from "clsx"

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
  return (
    <CustomPointer
      className="size-12 rounded-full bg-white shadow-md z-2"
      containerRef={containerRef}
      onClick={(data) => (data.isLeft ? onPrev?.() : onNext?.())}
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
