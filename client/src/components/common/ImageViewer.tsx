import { useEffect, useRef, useState } from "react"
import ImagePickerCarousel from "./ImagePickerCarousel"
import ImageViewerCursor from "./ImageViewerCursor"

interface ImageViewerProps {
  imagePaths: string[]
}
const ImageViewer = ({ imagePaths }: ImageViewerProps) => {
  const [viewingIndex, setViewingIndex] = useState(0)
  const [aspectRatio, setAspectRatio] = useState<number>(1)
  const viewerRef = useRef<HTMLDivElement>(null)

  const handleImageLoad = (e: React.SyntheticEvent<HTMLImageElement>) => {
    const { naturalWidth, naturalHeight } = e.currentTarget
    const raw = naturalWidth / naturalHeight

    setAspectRatio(Math.min(Math.max(raw, 0.75), 1.5))
  }

  const handlePrev = () => setViewingIndex((i) => Math.max(0, i - 1))
  const handleNext = () =>
    setViewingIndex((i) => Math.min(imagePaths.length - 1, i + 1))

  useEffect(() => setViewingIndex(0), [imagePaths])

  return (
    <div id="image-viewer" className="flex flex-col gap-6 grow">
      <div
        className="relative cursor-none w-full overflow-hidden max-h-150"
        style={{
          aspectRatio,
        }}
        ref={viewerRef}
      >
        <div
          className="mix-blend-darken flex transition-transform duration-500 ease-in-out w-full h-full"
          style={{ translate: `-${viewingIndex * 100}%` }}
        >
          {imagePaths.map((path, index) => (
            <img
              key={path}
              className="w-full h-full object-contain shrink-0"
              src={path}
              onLoad={index === viewingIndex ? handleImageLoad : undefined}
            />
          ))}
        </div>
        <ImageViewerCursor
          containerRef={viewerRef}
          onPrev={handlePrev}
          onNext={handleNext}
        />
      </div>
      <ImagePickerCarousel
        imagePaths={imagePaths}
        selected={viewingIndex}
        onSelected={setViewingIndex}
      />
    </div>
  )
}
export default ImageViewer
