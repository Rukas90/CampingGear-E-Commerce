import Skeleton, { type SkeletonStyleProps } from "react-loading-skeleton"
import { twMerge } from "tailwind-merge"

const SkeletonLine = ({
  className,
  enableAnimation = true,
  ...props
}: SkeletonStyleProps & { className?: string }) => {
  return (
    <Skeleton
      className="w-full h-full"
      containerClassName={twMerge("flex w-32 h-full rounded-lg", className)}
      enableAnimation={enableAnimation}
      {...props}
    />
  )
}
export default SkeletonLine
