import {
  ContrastButton,
  GoogleButton,
  HorizontalLineLabel,
  IconButton,
  IconX,
  PopButton,
} from "@components"
import type { AccountPanelProps } from "./AccountBadge"
import { Link } from "react-router-dom"

const AuthenticateAccountPanel = ({ onClose }: AccountPanelProps) => {
  return (
    <div className="flex flex-col gap-2 p-4 bg-white min-w-fit w-72 max-w-full rounded-md shadow-[0_0_50px_-12px_rgba(0,0,0,0.25)]">
      <div className="flex justify-between items-center gap-8 w-full mb-1">
        <p className="font-medium text-start">Authenticate</p>
        <IconButton
          className="text-neutral-600 size-5"
          icon={<IconX strokeWidth={4} />}
          onClick={onClose}
        />
      </div>
      <GoogleButton className="w-full py-2.5 text-sm" />
      <HorizontalLineLabel
        className="my-2"
        labelClassName="text-xs text-neutral-500"
        lineClassName="bg-neutral-300"
      >
        OR
      </HorizontalLineLabel>
      <Link to="/login">
        <ContrastButton className="w-full py-2.5 text-sm">Login</ContrastButton>
      </Link>
      <Link to="/register">
        <PopButton className="w-full py-2.5 text-sm">Register</PopButton>
      </Link>
    </div>
  )
}
export default AuthenticateAccountPanel
