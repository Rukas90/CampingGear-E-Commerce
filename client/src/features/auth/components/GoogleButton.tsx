import { BaseButton, IconGoogle, type ButtonProps } from "@features"
import { twMerge } from "tailwind-merge"

const GoogleButton = ({ className }: Omit<ButtonProps, "children">) => {
  const handleGoogleLogin = () => {
    window.location.href = `${import.meta.env.VITE_API_URL}/api/v1/auth/google/login`
  }
  return (
    <BaseButton
      type="button"
      onClick={handleGoogleLogin}
      className={twMerge(
        "flex items-center gap-3 font-medium justify-center py-2.5 border-black border-2 active:bg-black active:text-white",
        className,
      )}
    >
      <IconGoogle className="size-5" />
      Login via Google
    </BaseButton>
  )
}
export default GoogleButton
