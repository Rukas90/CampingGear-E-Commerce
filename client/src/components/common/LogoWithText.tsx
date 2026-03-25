import { IconMountain } from "@components"

const LogoWithText = () => {
  return (
    <div className="flex gap-2">
      <div className="shine">
        <IconMountain className="size-12 dark:text-stone-900 text-stone-800" />
      </div>
      <p className="font-medium text-xl dark:text-stone-200 text-stone-900 my-auto">
        <span className="font-semibold">Camping</span>{" "}
        <span className="font-medium playfair-display">Gear</span>
      </p>
    </div>
  )
}
export default LogoWithText
