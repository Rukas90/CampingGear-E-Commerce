import { IconCheckmark, IconX } from "@components"

interface RecommendBadgeProps {
  recommended?: boolean
  yesText?: string
  noText?: string
}
const RecommendBadge = ({
  recommended,
  yesText,
  noText,
}: RecommendBadgeProps) => {
  return (
    <div className="flex gap-2 items-center">
      {recommended ? (
        <IconCheckmark className="size-3.5 text-lime-600" />
      ) : (
        <IconX className="size-3 text-red-600" />
      )}
      <p className="text-sm text-neutral-700">
        {recommended ? yesText : noText}
      </p>
    </div>
  )
}
export default RecommendBadge
