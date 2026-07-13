import { IconAccount, IconButton } from "@components"
import { useAccount } from "@features"
import { useEffect, useRef, useState } from "react"
import AuthenticateAccountPanel from "./AuthenticateAccountPanel"
import ProfileAccountPanel from "./ProfileAccountPanel"
import { useLocation } from "react-router-dom"

export interface AccountPanelProps {
  onClose?: () => void
}

const AccountBadge = () => {
  const { account } = useAccount()
  const [showingPanel, setPanelVisibility] = useState(false)
  const containerRef = useRef<HTMLDivElement>(null)
  const { pathname } = useLocation()

  const authenticated = !!account

  const togglePanel = () => {
    setPanelVisibility((showing) => !showing)
  }
  const close = () => setPanelVisibility(false)

  useEffect(() => {
    if (!showingPanel) {
      return
    }

    const handleClickAway = (event: MouseEvent) => {
      if (!containerRef.current?.contains(event.target as Node)) {
        close()
      }
    }

    document.addEventListener("mousedown", handleClickAway)

    return () => document.removeEventListener("mousedown", handleClickAway)
  }, [showingPanel])

  useEffect(() => close(), [pathname])

  return (
    <div className="relative">
      <IconButton
        icon={
          <IconAccount className="size-5 dark:text-stone-100 text-stone-800 cursor-pointer" />
        }
        onClick={togglePanel}
      />
      {showingPanel && (
        <div className="absolute top-0 right-0 z-50" ref={containerRef}>
          {authenticated ? (
            <ProfileAccountPanel onClose={close} />
          ) : (
            <AuthenticateAccountPanel onClose={close} />
          )}
        </div>
      )}
    </div>
  )
}
export default AccountBadge
