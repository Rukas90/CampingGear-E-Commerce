import { twMerge } from "tailwind-merge"

const ContentBox = ({ children, className }: React.ComponentProps<"div">) => {
  return (
    <div
      className={twMerge(
        "w-full text-xm flex justify-between px-5 py-4 shadow-[0_0_14px_-4px_rgba(0,0,0,0.1)] rounded-2xl bg-white",
        className,
      )}
    >
      {children}
    </div>
  )
}
export default ContentBox
