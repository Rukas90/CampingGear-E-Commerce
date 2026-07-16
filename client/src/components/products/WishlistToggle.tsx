import { IconSaved } from "@components"

interface WishlistToggleProps {
  toggle: () => void
  isSaved: boolean
}
const WishlistToggle = ({ toggle, isSaved }: WishlistToggleProps) => {
  return (
    <button className="cursor-pointer" onClick={toggle}>
      <IconSaved className="size-5" fill={isSaved ? "#000000" : "none"} />
    </button>
  )
}
export default WishlistToggle
