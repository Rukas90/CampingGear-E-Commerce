import { PageWrapper, ProfileNavItem } from "@components"
import { Outlet } from "react-router-dom"

const AccountPage = () => {
  return (
    <PageWrapper className="w-full">
      <div className="flex py-12">
        <ul className="flex flex-col pr-48 gap-4 justify-center text-sm">
          <ProfileNavItem label="Profile" href="/profile" />
          <ProfileNavItem label="Orders" href="/orders" />
          <ProfileNavItem label="Addresses" href="/addresses" />
        </ul>
        <div className="basis-full">
          <Outlet />
        </div>
      </div>
    </PageWrapper>
  )
}
export default AccountPage
