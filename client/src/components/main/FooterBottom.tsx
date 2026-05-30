import { PageWrapper, PaymentMethods } from "@components"

const FooterBottom = () => {
  return (
    <div className="relative w-full bg-black py-2">
      <PageWrapper className="flex items-center justify-between">
        <PaymentMethods />
        <p className="text-stone-400 text-xm font-medium">
          @2026 TrailStore | All rights reserved
        </p>
      </PageWrapper>
    </div>
  )
}
export default FooterBottom
