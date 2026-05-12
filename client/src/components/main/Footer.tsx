import {
  CardDiscover,
  CardGooglePay,
  CardMastercard,
  CardPaypal,
  CardVisa,
  Newsletter,
  PageWrapper,
} from "@components"

const Footer = () => {
  return (
    <footer className="relative bg-[#f1f1ee]">
      <Newsletter />
      <div className="px-24 py-12">
        <PageWrapper>
          <div className="grid grid-cols-5 gap-6">
            <div>
              <p className="playfair-display text-lg font-semibold">Account</p>
              <ul className="mt-2 grid flex-col gap-2 text-base">
                <li className="text-stone-700">Your Account</li>
                <li className="text-stone-700">My Whishlist</li>
              </ul>
            </div>
            <div>
              <p className="playfair-display text-lg font-semibold">Shop</p>
              <ul className="mt-2 grid flex-col gap-2 text-base">
                <li className="text-stone-700">Bestsellers</li>
                <li className="text-stone-700">New Arrivals</li>
                <li className="text-stone-700">Gift Card</li>
              </ul>
            </div>
            <div>
              <p className="playfair-display text-lg font-semibold">Help</p>
              <ul className="mt-2 grid flex-col gap-2 text-base">
                <li className="text-stone-700">Customer Support</li>
                <li className="text-stone-700">Shipping Policy</li>
                <li className="text-stone-700">Returns & Refunds</li>
                <li className="text-stone-700">Warranty & Repair</li>
                <li className="text-stone-700">FAQ</li>
                <li className="text-stone-700">Privacy</li>
                <li className="text-stone-700">Terms of Service</li>
                <li className="text-stone-700">Terms & Conditions</li>
              </ul>
            </div>
            <div>
              <p className="playfair-display text-lg font-semibold">
                Work with Us
              </p>
              <ul className="mt-2 grid flex-col gap-2 text-base">
                <li className="text-stone-700">Jobs & Careers</li>
                <li className="text-stone-700">Co-op Culture</li>
                <li className="text-stone-700">Affiliate Program</li>
              </ul>
            </div>
            <div>
              <p className="playfair-display text-lg font-semibold">
                Connect with us
              </p>
              <ul className="mt-2 grid flex-col gap-2 text-base">
                <li className="text-stone-700">Camping Gear EU</li>
                <li className="text-stone-700">Phone: +12 (345) 678-999</li>
                <li className="text-stone-700">Email: info@campgear.com</li>
                <li className="text-stone-700">
                  Hours:Monday-Friday, 8:30am-5pm CET
                </li>
              </ul>
            </div>
          </div>
        </PageWrapper>
      </div>

      <div className="relative w-full bg-black py-2">
        <PageWrapper className="flex items-center justify-between">
          <div className="flex gap-2">
            <CardMastercard className="h-5 rounded-sm" />
            <CardVisa className="h-5 rounded-sm" />
            <CardPaypal className="h-5 rounded-sm" />
            <CardDiscover className="h-5 rounded-sm" />
            <CardGooglePay className="h-5 rounded-sm" />
          </div>
          <p className="text-stone-300 text-sm font-medium">
            @2026 TrailStore | All rights reserved
          </p>
        </PageWrapper>
      </div>
    </footer>
  )
}
export default Footer
