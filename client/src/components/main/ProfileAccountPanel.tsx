import { ContrastButton, IconButton, IconX, PopButton } from "@components"
import { useAccount } from "@features"
import type { AccountPanelProps } from "./AccountBadge"
import { Link } from "react-router-dom"

const ProfileAccountPanel = ({ onClose }: AccountPanelProps) => {
  const { account } = useAccount()
  return (
    <div className="flex flex-col p-4 bg-white min-w-fit w-72 max-w-full rounded-md shadow-[0_0_50px_-12px_rgba(0,0,0,0.25)]">
      <div className="flex justify-between items-center gap-8 w-full">
        <p className="font-medium text-start">Account</p>
        <IconButton
          className="text-neutral-600 size-5"
          icon={<IconX strokeWidth={4} />}
          onClick={onClose}
        />
      </div>
      <p className="mb-4 text-sm text-neutral-400 mt-1">{account?.email}</p>
      <div className="w-full flex gap-2">
        <Link to="/profile" target="_self" className="basis-1/2">
          <ContrastButton className="w-full py-2.5 text-sm">
            Profile
          </ContrastButton>
        </Link>
        <PopButton className="w-full py-2.5 text-sm basis-1/2">
          Orders
        </PopButton>
      </div>
    </div>
  )
}
export default ProfileAccountPanel
