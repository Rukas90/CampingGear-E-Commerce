import { Button } from "@features"
import Banner from "/img/banner.webp"

const HomePage = () => {
  return (
    <>
      <title>Trailstore</title>
      <div className="flex justify-center w-full">
        <p className="flex flex-col items-center pt-10 text-2xl gap-1">
          <span className="font-semibold">Find the latest Camping Gear</span>
          <span>from the most respectable brands </span>
          <span className="flex gap-4">
            <Button fill="outline">Shop All</Button>
            <Button style="contrast">Shop New</Button>
          </span>
        </p>
      </div>
      <img
        src={Banner}
        className="relative w-full object-cover object-bottom-right pointer-events-none"
      />
    </>
  )
}
export default HomePage
