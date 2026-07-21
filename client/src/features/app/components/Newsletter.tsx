import { Button, InputField, Line } from "@features"

const Newsletter = () => {
  return (
    <div className="relative w-full py-8 bg-[#f1f1ee] overflow-hidden">
      <Line className="absolute top-0 left-0" />
      <img
        src="/img/forest-nature-backdrop.webp"
        className="absolute mx-auto h-full left-1/2 top-1/2 -translate-y-1/2 scale-125 -translate-1/2 mix-blend-darken opacity-2.5 select-none pointer-events-none"
      />
      <div className="relative flex flex-col gap-3 items-center justify-center z-1 sm:px-12 px-4">
        <div className="flex w-full items-center">
          <Line className="bg-stone-400 sm:block hidden" />
          <p className="font-black sm:text-xl text-sm uppercase font-serif sm:shrink-0 sm:mx-8 mx-auto text-center scale-y-110">
            Camping Gear Line
          </p>
          <Line className="bg-stone-400 sm:block hidden" />
        </div>
        <p className="sm:text-base text-xm text-center">
          Join our mailing list to receive the latest news and promotions.
        </p>
        <div className="flex sm:flex-row flex-col gap-2 justify-center sm:w-[384px] w-full">
          <span className="w-full">
            <InputField
              className="text-base w-full rounded-lg bg-stone-50"
              placeholder="Email Address"
            />
          </span>
          <Button
            style="contrast"
            fill="filled"
            radius="halfRound"
            className="mt-0 sm:w-32 w-full"
          >
            Subscribe
          </Button>
        </div>
        <p className="sm:text-base text-xm text-center sm:w-125 max-w-full mx-auto text-stone-700">
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
