import { Button, InputField } from "@components"

const Newsletter = () => {
  return (
    <div className="relative w-full py-8 bg-[#eeeae6]">
      <img
        src="/img/forest-nature-backdrop.webp"
        className="absolute mx-auto h-full left-1/2 top-1/2 -translate-1/2"
      />
      <div className="relative flex flex-col gap-3 items-center justify-center z-1">
        <p className="font-semibold text-3xl">20% Off your first order!</p>
        <p className="text-lg">
          Join our mailing list to receive the latest news and promotions.
        </p>
        <div className="flex gap-2 justify-center w-[384px]">
          <span className="w-full">
            <InputField
              className="text-base! w-full"
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
