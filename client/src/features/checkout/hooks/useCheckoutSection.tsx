import { useCheckoutContext, type UseDataSnapshot } from "@features"
import { useEffect, useRef, useState } from "react"

const useCheckoutSection = ({
  name,
  data,
}: {
  name: string
  data: UseDataSnapshot
}) => {
  const { registerSection } = useCheckoutContext()
  const [isEditing, setEditing] = useState(false)
  const ref = useRef<HTMLDivElement>(null)

  useEffect(() => {
    return registerSection(name, openAndScroll)
  }, [name])

  const edit = () => {
    data.makeSnapshot()
    setEditing(true)
  }

  const close = () => {
    setEditing(false)
  }

  const cancel = () => {
    data.revertToSnapshot()
    setEditing(false)
  }

  const scrollIntoView = () =>
    ref.current?.scrollIntoView({ behavior: "smooth", block: "start" })

  const openAndScroll = () => {
    edit()
    scrollIntoView()
  }

  const toggleEdit = () => {
    if (isEditing) {
      cancel()
      return
    }
    edit()
  }

  return {
    isEditing,
    ref,
    edit,
    close,
    cancel,
    toggleEdit,
  }
}
export default useCheckoutSection
