import { twMerge } from "tailwind-merge"

const NavMenuItem = ({
  children,
  className,
  ...props
}: React.ComponentProps<"li">) => (
  <li
    className={twMerge("group font-normal text-sm cursor-default", className)}
    {...props}
  >
    {children}
  </li>
)
export default NavMenuItem
