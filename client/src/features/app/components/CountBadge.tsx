import { DotCount } from "@features"

interface CountBadgeProps {
  icon: React.ComponentType<any>
  count: number
}
const CountBadge = ({ icon: Icon, count }: CountBadgeProps) => {
  return (
    <div className="relative">
      <Icon className="size-5 dark:text-stone-100 text-stone-800" />
      <DotCount count={count} />
    </div>
  )
}
export default CountBadge
