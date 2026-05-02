import { IconGoogle } from "@components"
import { Button } from "."

const GoogleButton = () => {
  return (
    <Button
      className="flex items-center gap-3 font-medium justify-center py-2.5 border-black border-2"
      style="pale"
    >
      <IconGoogle className="size-5" />
      Login via Google
    </Button>
  )
}
export default GoogleButton
