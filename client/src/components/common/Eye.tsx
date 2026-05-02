import { IconVisibilityOff, IconVisibilityOn } from "@components/img"
import type { SVGProps } from "react"

interface EyeProps extends SVGProps<SVGSVGElement> {
  state?: boolean
}
const Eye = ({ state, ...props }: EyeProps) => {
  return state ? (
    <IconVisibilityOn {...props} />
  ) : (
    <IconVisibilityOff {...props} />
  )
}
export default Eye
