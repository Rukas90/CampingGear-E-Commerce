import { Button, InputField, Line } from "@components"

const Newsletter = () => {
  return (
    <div className="relative w-full py-8 bg-[#f1f1ee]">
      <img
        src="/img/forest-nature-backdrop.webp"
        className="absolute mx-auto h-full left-1/2 top-1/2 -translate-y-1/2 scale-125 -translate-1/2 mix-blend-darken opacity-5 select-none pointer-events-none"
      />
      <div className="relative flex flex-col gap-3 items-center justify-center z-1">
        <div className="flex w-full items-center">
          <Line className="bg-stone-400" />
          <p className="font-black text-xl uppercase font-serif shrink-0 mx-8">
            Camping Gear Line
          </p>
          <Line className="bg-stone-400" />
        </div>
        <p className="text-base">
          Join our mailing list to receive the latest news and promotions.
        </p>
        <div className="flex gap-2 justify-center w-[384px]">
          <span className="w-full">
            <InputField
              className="text-base w-full rounded-lg"
              placeholder="Email Address"
            />
          </span>
          <Button
            style="contrast"
            fill="filled"
            radius="halfRound"
            className="w-32 mt-0"
          >
            Subscribe
          </Button>
        </div>
        <p className="text-sm w-125 text-center mx-auto text-stone-700">
          By submitting, you agree to the processing of your personal data in
          accordance with our{" "}
          <span className="font-bold text-lime-800">privacy policy</span>. We do
          not share your personal data with third parties.
        </p>
      </div>
    </div>
  )
}
export default Newsletter
