import {
  useCartContext,
  useErrorPool,
  useQueryHandler,
  type ErrorPool,
} from "@features"
import { createContext, useContext, useRef } from "react"
import useCheckoutForm from "../hooks/useCheckoutForm"
import type { CheckoutForm } from "@types"
import checkoutApi from "../api/checkoutApi"
import { useNavigate } from "react-router-dom"
import useCheckoutConfirm from "../hooks/useCheckoutConfirm"
import { hasError } from "@lib"

interface CheckoutContextData {
  form?: CheckoutForm
  isPending: boolean
  errors: ErrorPool
  registerSection: (name: string, activate: () => void) => void
  confirm: (saveInformation: boolean) => void
}

const CheckoutContext = createContext<CheckoutContextData | undefined>(
  undefined,
)

const CheckoutProvider = ({ children }: React.PropsWithChildren) => {
  const navigate = useNavigate()
  const query = useQueryHandler({
    key: ["checkout"],
    func: () => checkoutApi.init(),
    retry: false,
    onError: (pd) => {
      if (
        hasError(pd, [
          "checkout.empty_cart",
          "checkout.no_session",
          "checkout.already_complete",
        ])
      ) {
        navigate("/")
      }
    },
  })
  const { form, isPending } = useCheckoutForm({
    enabled: !query.isPending,
  })
  const errors = useErrorPool()
  const { invalidateCart } = useCartContext()

  const sections = useRef<Map<string, () => void>>(new Map())

  const confirm = useCheckoutConfirm({
    onSuccess: async (orderId) => {
      await invalidateCart()
      navigate(`/orders/pay/${orderId}`)
    },
    onError: (problem) => {
      errors.setErrors(problem.errors)
      const firstScope = problem.errors[0]?.name.split(".")[0]
      sections.current.get(firstScope)?.()
    },
  })

  const registerSection = (name: string, activate: () => void) => {
    sections.current.set(name, activate)
    return () => sections.current.delete(name)
  }

  const handleConfirm = async (saveInformation: boolean) => {
    if (!confirm.isPending) {
      await confirm.mutateAsync(saveInformation)
    }
  }

  if (isPending) {
    return
  }
  if (!query.isPending && !query.data) {
    navigate("/")
    return
  }

  return (
    <CheckoutContext.Provider
      value={{
        form,
        isPending,
        errors,
        registerSection,
        confirm: handleConfirm,
      }}
    >
      {children}
    </CheckoutContext.Provider>
  )
}
export default CheckoutProvider

export const useCheckoutContext = () => {
  const context = useContext(CheckoutContext)

  if (!context) {
    throw new Error("useCheckoutContext must be used within CheckoutProvider.")
  }
  return context
}
