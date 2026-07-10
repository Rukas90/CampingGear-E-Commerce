import { IconSuccess, IconError } from "@components"
import { twMerge } from "tailwind-merge"

export type MessageBoxVariant = "success" | "error"

interface MessageBoxProps extends React.ComponentProps<"div"> {
  variant?: MessageBoxVariant
}

const variantStyles: Record<
  MessageBoxVariant,
  { icon: React.ElementType; bg: string; accent: string; text: string }
> = {
  success: {
    icon: IconSuccess,
    bg: "bg-[#eceeea]",
    accent: "bg-accent",
    text: "text-accent",
  },
  error: {
    icon: IconError,
    bg: "bg-[#f1e8e8]",
    accent: "bg-danger",
    text: "text-danger",
  },
}

const MessageBox = ({
  className,
  children,
  variant = "success",
  ...props
}: MessageBoxProps) => {
  const { icon: Icon, bg, accent, text } = variantStyles[variant]
  return (
    <div
      className={twMerge("min-h-16 relative flex items-center", bg, className)}
      {...props}
    >
      <div className={twMerge("absolute h-full min-w-1", accent)} />
      <div className="ml-1 px-6 flex items-center gap-2">
        <Icon className={twMerge("size-5", text)} />
        {children}
      </div>
    </div>
  )
}
export default MessageBox
