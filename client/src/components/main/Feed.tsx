import {
  FreeShippingNote,
  ReturnPolicyNote,
  IconArrow,
  IconButton,
} from "@components"
import { useRef, useState } from "react"
import { flushSync } from "react-dom"

const Feed = () => {
  const shiftRef = useRef<HTMLDivElement | null>(null)
  const transitioning = useRef<boolean>(false)

  const [index, setIndex] = useState(0)

  const notes = [FreeShippingNote, ReturnPolicyNote] as const

  const Previous = index > 0 ? notes[index - 1] : notes[notes.length - 1]
  const Current = notes[index]
  const Next = index < notes.length - 1 ? notes[index + 1] : notes[0]

  const SHIFT_AMOUNT = 288 // Pixels, equevelent to w-72

  const next = () => {
    let newIndex = index + 1

    if (newIndex > notes.length - 1) {
      newIndex = 0
    }
    transition(newIndex, "right")
  }
  const prev = () => {
    let newIndex = index - 1

    if (newIndex < 0) {
      newIndex = notes.length - 1
    }
    transition(newIndex, "left")
  }

  const waitForTransition = (el: HTMLElement): Promise<void> =>
    new Promise((resolve) =>
      el.addEventListener("transitionend", () => resolve(), { once: true }),
    )

  const transition = async (newIndex: number, direction: "left" | "right") => {
    if (!shiftRef.current || transitioning.current) {
      return
    }
    transitioning.current = true

    const el = shiftRef.current
    const offset = direction === "right" ? -SHIFT_AMOUNT : SHIFT_AMOUNT

    el.style.transition = "transform 300ms ease"
    el.style.transform = `translateX(${offset}px)`

    await waitForTransition(el)

    el.style.transition = "none"
    el.style.transform = "translateX(0)"

    flushSync(() => {
      setIndex(newIndex)
    })
    transitioning.current = false
  }

  return (
    <div className="w-full p-3 bg-[#1a1a1a]">
      <div className="flex gap-4 justify-center items-center">
        <IconButton
          icon={<IconArrow className="text-stone-50 size-4.5 rotate-180" />}
          onClick={prev}
        />
        <div
          className="w-72 overflow-hidden"
          style={{
            maskImage:
              "linear-gradient(to right, transparent, black 5%, black 95%, transparent)",
          }}
        >
          <div
            ref={shiftRef}
            className="relative flex flex-nowrap w-72 pointer-events-none"
          >
            <a className="flex shrink-0 w-72 justify-center absolute right-full">
              <Previous />
            </a>
            <a className="flex shrink-0 w-72 justify-center">
              <Current />
            </a>
            <a className="flex shrink-0 w-72 justify-center absolute left-full">
              <Next />
            </a>
          </div>
        </div>
        <IconButton
          icon={<IconArrow className="text-stone-50 size-4.5" />}
          onClick={next}
        />
      </div>
    </div>
  )
}
export default Feed
