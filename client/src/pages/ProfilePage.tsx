import { OutlineButton, TextButton } from "@components"
import { useAccount } from "@features"

const ProfilePage = () => {
  const { account, signOut } = useAccount()

  return (
    <div className="flex flex-col gap-5 items-start">
      <div className="w-full text-xm flex justify-between px-5 py-4 shadow-[0_0_14px_-4px_rgba(0,0,0,0.1)] rounded-2xl bg-white">
        <p className="text-neutral-500 font-light">Email Address</p>
        <p className="text-accent">{account?.email}</p>
      </div>
      <div className="flex gap-5">
        <OutlineButton
          onClick={signOut}
          className="py-2 text-sm px-4 border border-neutral-200 not-disabled:hover:border-neutral-200 text-accent hover:text-accent-dark"
        >
          Sign out
        </OutlineButton>
        <TextButton>Sign out of all devices</TextButton>
      </div>
    </div>
  )
}
export default ProfilePage
