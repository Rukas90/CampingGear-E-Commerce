import { cva, type VariantProps } from "class-variance-authority"
import { twMerge } from "tailwind-merge"

const none = "" as const

const ButtonClasses = cva(
  "px-4 py-2 mt-2 text-base font-normal transition-colors cursor-pointer disabled:cursor-not-allowed disabled:pointer-events-none",
  {
    variants: {
      fill: {
        filled: none,
        outline: "border",
        ghost: none,
      },
      radius: {
        rounded: "rounded-xl",
        halfRound: "rounded-lg",
        hardEdge: "rounded-none",
      },
      style: {
        pale: none,
        contrast: none,
      },
    },
    compoundVariants: [
      { fill: "filled", style: "pale", class: "bg-natural-100 text-stone-900" },
      {
        fill: "outline",
        style: "pale",
        class: "bg-transparent text-stone-900 border-stone-200",
      },
      { fill: "ghost", style: "pale", class: "bg-transparent text-stone-900" },

      {
        fill: "filled",
        style: "contrast",
        class:
          "bg-stone-800 hover:bg-stone-900 active:bg-stone-950 disabled:bg-stone-700 text-stone-100 disabled:text-stone-400",
      },
      {
        fill: "outline",
        style: "contrast",
        class: "bg-transparent text-stone-100 border-stone-800",
      },
      {
        fill: "ghost",
        style: "contrast",
        class: "bg-transparent text-stone-800",
      },
    ],
    defaultVariants: {
      fill: "filled",
      radius: "halfRound",
      style: "pale",
    },
  },
)
interface ButtonProps
  extends
    Omit<React.ComponentProps<"button">, "style">,
    VariantProps<typeof ButtonClasses> {}

const Button = ({
  fill = "filled",
  radius = "halfRound",
  style = "pale",
  className,
  children,
  ...props
}: ButtonProps) => {
  return (
    <button
      className={twMerge(ButtonClasses({ fill, radius, style }), className)}
      {...props}
    >
      {children}
    </button>
  )
}
export default Button
