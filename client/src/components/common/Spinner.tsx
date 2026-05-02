import { IconSpinner } from "@components/img"
import clsx from "clsx"

const Spinner = ({ className, ...props }: React.SVGProps<SVGSVGElement>) => {
  return <IconSpinner className={clsx(className, "animate-spin")} {...props} />
}
export default Spinner
