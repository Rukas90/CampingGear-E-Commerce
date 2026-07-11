import { useMutation } from "@tanstack/react-query"
import { useNavigate } from "react-router-dom"
import type { LoginData } from "../schemas"
import { authApi } from "../api"
import { HandleReqFn } from "@lib"
import type { CustomerAccount, ProblemDetails } from "@types"
import useAccount from "./useAccount"
import { useSessionSummary } from "@features"

const useLogin = () => {
  const navigate = useNavigate()
  const { invalidate } = useSessionSummary()
  const { setAccount } = useAccount()

  return useMutation<CustomerAccount, ProblemDetails, LoginData>({
    mutationFn: (data: LoginData) => HandleReqFn(() => authApi.login(data)),
    onSuccess: async (account) => {
      setAccount(account)
      await invalidate()
      navigate("/")
    },
    onError: () => {
      setAccount(null)
    },
  })
}

export default useLogin
