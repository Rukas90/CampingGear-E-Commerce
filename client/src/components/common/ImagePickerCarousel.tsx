import { IconArrow, IconButton } from "@components"
import clsx from "clsx"
import { useEffect, useRef, useState } from "react"

interface ProductImagePickerProps {
  imagePaths: string[] | undefined
  selected?: number
  onSelected?: (index: number) => void
}

const ITEM_SIZE = 95
const ITEM_GAP = 8
const ITEM_STEP = ITEM_SIZE + ITEM_GAP

const ImagePickerCarousel = ({
  imagePaths,
  selected,
  onSelected,
}: ProductImagePickerProps) => {
  const [offset, setOffset] = useState(0)
  const scrollProgressRef = useRef(0)

  const viewportRef = useRef<HTMLDivElement | null>(null)
  const containerRef = useRef<HTMLUListElement | null>(null)

  const FULL_SHIFT_AMOUNT = ITEM_SIZE * 7

  const maxOffset = () => {
    if (!viewportRef.current || !containerRef.current) {
      return 0
    }
    return containerRef.current.scrollWidth - viewportRef.current.clientWidth
  }

  const canScroll = () => {
    if (!viewportRef.current || !containerRef.current) {
      return false
    }
    return containerRef.current.scrollWidth > viewportRef.current.clientWidth
  }

  const scrollBackward = () =>
    setOffset((o) => {
      const next = Math.max(0, o - FULL_SHIFT_AMOUNT)
      scrollProgressRef.current = next / maxOffset()
      return next
    })

  const scrollForward = () =>
    setOffset((o) => {
      const next = Math.min(maxOffset(), o + FULL_SHIFT_AMOUNT)
      scrollProgressRef.current = next / maxOffset()
      return next
    })

  const nudgeForSelected = (index: number) => {
    const viewport = viewportRef.current

    if (!viewport) {
      return
    }
    onSelected?.(index)

    const firstVisible = Math.round(offset / ITEM_STEP)
    const visibleCount = Math.floor(viewport.clientWidth / ITEM_STEP)
    const lastVisible = firstVisible + visibleCount - 1

    if (index <= firstVisible && canScroll()) {
      setOffset((o) => {
        const next = Math.max(0, o - ITEM_STEP)
        scrollProgressRef.current = next / maxOffset()
        return next
      })
    } else if (index >= lastVisible && canScroll()) {
      setOffset((o) => {
        const next = Math.min(maxOffset(), o + ITEM_STEP)
        scrollProgressRef.current = next / maxOffset()
        return next
      })
    }
  }

  useEffect(() => {
    const viewport = viewportRef.current

    if (!viewport) {
      return
    }

    const observer = new ResizeObserver(() => {
      if (!canScroll()) {
        setOffset(0)
        scrollProgressRef.current = 0
        return
      }
      const newMax = maxOffset()
      const adjusted = Math.round(scrollProgressRef.current * newMax)

      setOffset(Math.min(adjusted, newMax))
    })

    observer.observe(viewport)
    return () => observer.disconnect()
  }, [])

  const canScrollBack = canScroll() && offset > 0
  const canScrollForward = canScroll() && offset < maxOffset()

  return (
    <div className="flex items-center gap-5">
      <IconButton
        onClick={scrollBackward}
        icon={<IconArrow className="text-neutral-400 size-4 rotate-180" />}
        disabled={!canScroll()}
      />
      <div
        className="overflow-hidden w-full"
        ref={viewportRef}
        style={{
          maskImage: `linear-gradient(to right, ${canScrollBack ? "transparent" : "black"} 0%, black 5%, black 95%, ${canScrollForward ? "transparent" : "black"} 100%)`,
        }}
      >
        <ul
          className="inline-flex gap-1.75 transition-transform duration-200 ease-in-out"
          style={{ translate: -offset, gap: ITEM_GAP }}
          ref={containerRef}
        >
          {imagePaths?.map((path, index) => {
            const isSelected = selected === index

            return (
              <li
                key={path}
                onClick={() => nudgeForSelected?.(index)}
                style={{
                  width: ITEM_SIZE,
                  height: ITEM_SIZE,
                  minWidth: ITEM_SIZE,
                }}
                className={clsx(
                  "grow border border-b-2 p-1 transition-colors rounded-2xl border-stone-100 bg-[#f3f3f1]",
                  isSelected && "border-b-[#d5d2c9]",
                  !isSelected && "hover:border-b-[#d1d1d1]",
                )}
              >
                <img
                  className="w-full h-full object-contain mix-blend-darken"
                  src={path}
                />
              </li>
            )
          })}
        </ul>
      </div>
      <IconButton
        onClick={scrollForward}
        icon={<IconArrow className="text-neutral-400 size-4" />}
        disabled={!canScroll()}
      />
    </div>
  )
}
export default ImagePickerCarousel
