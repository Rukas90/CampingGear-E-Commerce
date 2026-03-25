import {
  ContentContainer,
  Feed,
  Footer,
  InputField,
  PageWrapper,
  TopNav,
} from "@components"
import Banner from "/img/banner.webp"

const HomePage = () => {
  return (
    <div className="w-full h-full min-h-svh">
      <div className="flex flex-col">
        <TopNav />
        <ContentContainer>
          <Feed />
          <div className="flex justify-center w-full">
            <p className="flex flex-col items-center pt-10 text-xl gap-1">
              <span>Find the latest Camping Gear</span>
              <span>from the most respectable brands </span>
              <button className="bg-white border border-stone-200 rounded-lg px-4 py-2 mt-2 text-base font-normal">
                Start Exploring
              </button>
            </p>
          </div>
          <img
            src={Banner}
            className="relative w-full object-cover object-bottom-right -translate-y-6"
          />
          <div className="mt-6">
            <PageWrapper>
              <p className="text-3xl font-bold text-stone-800 playfair-display">
                Top categories
              </p>
              <div className="grid grid-cols-4 gap-4 my-8">
                <div className="h-60 group">
                  <div className="h-48 bg-[#f1f1ee] rounded-md shine">
                    <img
                      src="products/gpsmap67/gpsmap-67-xl.webp"
                      className="h-full mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
                    />
                  </div>
                  <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
                    Handheld GPS
                  </p>
                </div>
                <div className="h-60 group">
                  <div className="h-48 bg-[#f1f1ee] rounded-md shine">
                    <img
                      src="products/tents/durston-x-mid-pro-1---3.webp"
                      className="h-full mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
                    />
                  </div>
                  <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
                    Tents
                  </p>
                </div>
                <div className="h-60 group">
                  <div className="h-48 bg-[#f1f1ee] rounded-md p-4 shine">
                    <img
                      src="products/backpacks/gregory-baltoro-75-man.avif"
                      className="h-full mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
                    />
                  </div>
                  <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
                    backpacks
                  </p>
                </div>
                <div className="h-60 group">
                  <div className="h-48 bg-[#f1f1ee] rounded-md shine">
                    <img
                      src="products/sleeping-bags/western-mountaineering-alpinlite-20.jpg"
                      className="h-full mx-auto mix-blend-darken group-hover:scale-110 will-change-transform transition-transform"
                    />
                  </div>
                  <p className="w-full mt-4 text-center text-xl text-stone-600 group-hover:text-stone-800 transition-colors">
                    Sleeping bags
                  </p>
                </div>
              </div>
              <p className="text-3xl font-bold text-stone-800 playfair-display">
                Why shop here
              </p>
              <div className="grid grid-cols-4 gap-4 my-8">
                <div className="h-48 border-2 border-[#e4dcd7] rounded-md p-4">
                  <p className="text-xl font-medium">Store pickup</p>
                  <p>sadasd</p>
                </div>
              </div>
            </PageWrapper>
            <div className="relative w-full py-8 bg-[#eeeae6]">
              <img
                src="img/forest-nature-backdrop.webp"
                className="absolute mx-auto h-full left-1/2 top-1/2 -translate-1/2"
              />
              <div className="relative flex flex-col gap-4 items-center justify-center z-1">
                <p className="text-3xl">15% off your first order!</p>
                <p className="text-lg">
                  Join our mailing list to receive the latest news and
                  promotions.
                </p>
                <div className="flex gap-2 mt-2 justify-center w-full">
                  <InputField
                    className="text-lg! rounded-lg"
                    placeholder="Email Address"
                  />
                  <button className="bg-stone-800 px-4 py-2 text-stone-200 rounded">
                    Subscribe
                  </button>
                </div>
              </div>
            </div>
          </div>
        </ContentContainer>
      </div>
      <Footer />
    </div>
  )
}
export default HomePage
