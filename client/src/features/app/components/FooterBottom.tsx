import { PageWrapper, PaymentMethods } from "@features"

const FooterBottom = () => {
  return (
    <div className="relative w-full bg-black sm:py-2 py-4">
      <PageWrapper className="flex gap-4 sm:flex-row flex-col-reverse items-center justify-between">
        <PaymentMethods />
        <p className="text-stone-400 sm:text-xm text-xs font-medium text-center">
          @2026 TrailStore | All rights reserved
        </p>
      </PageWrapper>
    </div>
  )
}
export default FooterBottom
