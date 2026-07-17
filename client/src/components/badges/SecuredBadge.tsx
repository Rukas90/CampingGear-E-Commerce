import { IconLock } from "@components"

const SecuredBadge = () => (
  <p className="flex items-center gap-1 mx-auto text-xs mt-3 text-neutral-600">
    <IconLock className="size-3.5 text-neutral-500" />{" "}
    <span>Secured by Stripe</span>
  </p>
)
export default SecuredBadge
