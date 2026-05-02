interface CountBadgeProps {
  icon: React.ComponentType<any>
  count: number
}
const CountBadge = ({ icon: Icon, count }: CountBadgeProps) => {
  return (
    <div className="relative">
      <Icon className="size-5 dark:text-stone-100 text-stone-800" />
      <span className="absolute bg-black inter text-stone-200 text-[11px] font-semibold min-w-3.75 h-3.75 p-1 rounded-full flex items-center justify-center outline-2 outline-white -right-2 -top-2">
        {count > 99 ? "99+" : count}
      </span>
    </div>
  )
}
export default CountBadge
