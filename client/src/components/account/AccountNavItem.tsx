import { NavLink } from "react-router-dom"

interface AccountNavItemProps {
  label: string
  href: string
}
const AccountNavItem = ({ label, href }: AccountNavItemProps) => (
  <NavLink
    to={href}
    className={({ isActive }) =>
      isActive
        ? "text-accent-dark underline font-semibold"
        : " text-neutral-500 hover:text-neutral-800 transition-colors"
    }
  >
    <li>{label}</li>
  </NavLink>
)
export default AccountNavItem
