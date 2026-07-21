import { Slider, SliderThumb, SliderTrack } from "react-aria-components"

interface RangeSliderProps {
  min: number
  max: number
  defaultValue?: [number, number]
  onChange?: (value: [number, number]) => void
  onChanging?: (value: [number, number]) => void
}

const RangeSlider = ({
  min,
  max,
  defaultValue,
  onChange,
  onChanging,
}: RangeSliderProps) => {
  const isSameMinMax = min === max

  return (
    <Slider
      minValue={min}
      maxValue={max}
      defaultValue={defaultValue}
      onChange={onChanging}
      onChangeEnd={(v) => onChange?.(v as [number, number])}
      className="w-full py-2"
      isDisabled={isSameMinMax}
    >
      <SliderTrack className="relative h-1 w-full bg-neutral-300 rounded">
        {({ state }) => (
          <>
            <div
              className="absolute h-0.5 translate-y-1/2 bg-lime-800 rounded"
              style={
                isSameMinMax
                  ? { left: "0%", width: "100%" }
                  : {
                      left: `${state.getThumbPercent(0) * 100}%`,
                      width: `${(state.getThumbPercent(1) - state.getThumbPercent(0)) * 100}%`,
                    }
              }
            />
            <SliderThumb
              index={0}
              className="block size-4.5 rounded-full border-2 border-neutral-600 bg-neutral-100 cursor-grab pressed:cursor-grabbing outline-none top-1/2"
            />
            <SliderThumb
              index={1}
              className="block size-4.5 rounded-full border-2 border-neutral-600 bg-neutral-100 cursor-grab pressed:cursor-grabbing outline-none top-1/2"
              style={isSameMinMax ? { left: "100%" } : undefined}
            />
          </>
        )}
      </SliderTrack>
    </Slider>
  )
}
export default RangeSlider
