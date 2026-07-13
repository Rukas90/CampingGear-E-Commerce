import { IconGoogle } from "@components"
import { Button } from "."
import type { ButtonProps } from "./BaseButton"
import { twMerge } from "tailwind-merge"

const GoogleButton = ({ className }: Omit<ButtonProps, "children">) => {
  return (
    <Button
      className={twMerge(
        "flex items-center gap-3 font-medium justify-center py-2.5 border-black border-2",
        className,
      )}
      style="pale"
    >
      <IconGoogle className="size-5" />
      Login via Google
    </Button>
  )
}
export default GoogleButton
