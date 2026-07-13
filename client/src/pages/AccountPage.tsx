import { PageWrapper, AccountNavItem } from "@components"
import { Outlet } from "react-router-dom"

const AccountPage = () => {
  return (
    <PageWrapper className="w-full">
      <div className="flex lg:flex-row flex-col py-12">
        <ul className="flex lg:flex-col flex-row lg:pr-48 lg:mb-0 mb-8 lg:gap-4 gap-6 justify-center lg:text-sm text-base h-full">
          <AccountNavItem label="Profile" href="/profile" />
          <AccountNavItem label="Orders" href="/orders" />
          <AccountNavItem label="Addresses" href="/addresses" />
        </ul>
        <div className="grow">
          <Outlet />
        </div>
      </div>
    </PageWrapper>
  )
}
export default AccountPage
