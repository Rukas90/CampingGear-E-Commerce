import { Line, Newsletter, PageWrapper } from "@features"
import FooterBottom from "./FooterBottom"
import FooterNavigationSection from "./FooterNavigationSection"

const Footer = () => {
  return (
    <footer className="relative bg-[#f1f1ee]">
      <Newsletter />
      <div className="xl:px-24 px-4 py-12">
        <PageWrapper className="w-full">
          <div className="flex xl:flex-row flex-col xl:gap-24 gap-4">
            <FooterNavigationSection
              header="Account"
              items={[{ name: "Your Account" }, { name: "My Whishlist" }]}
            />
            <Line className="xl:hidden block" />
            <FooterNavigationSection
              header="Help"
              items={[
                { name: "Customer Support" },
                { name: "Shipping Policy" },
                { name: "Returns & Refunds" },
                { name: "Warranty & Repair" },
                { name: "FAQ" },
                { name: "Privacy" },
                { name: "Terms of Service" },
                { name: "Terms & Conditions" },
              ]}
            />
            <Line className="xl:hidden block" />
            <div className="xl:ml-auto xl:mr-0 mr-auto">
              <p className="playfair-display text-lg font-semibold text-start">
                Connect with us
              </p>
              <ul className="mt-2 grid flex-col gap-2 text-base text-start">
                <li className="text-stone-700">TrailStore Gear EU</li>
                <li className="text-stone-700">Phone: +12 (345) 678-999</li>
                <li className="text-stone-700">Email: info@trailstore.com</li>
                <li className="text-stone-700">
                  Hours: Monday-Friday, 8:30am-5pm CET
                </li>
              </ul>
            </div>
          </div>
        </PageWrapper>
      </div>
      <FooterBottom />
    </footer>
  )
}
export default Footer
