import { useMutation } from "@tanstack/react-query"
import { useNavigate } from "react-router-dom"
import type { LoginData } from "../schemas"
import { authApi } from "../api"
import { handleQueryFn } from "@lib"
import type { CustomerAccount, ProblemDetails } from "@types"
import useAccount from "./useAccount"

const useLogin = () => {
  const navigate = useNavigate()
  const { setAccount } = useAccount()

  return useMutation<CustomerAccount, ProblemDetails, LoginData>({
    mutationFn: (data: LoginData) => handleQueryFn(() => authApi.login(data)),
    onSuccess: (account) => {
      setAccount(account)
      navigate("/")
    },
    onError: () => {
      setAccount(null)
    },
  })
}

export default useLogin
