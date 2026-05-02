import { useMutation } from "@tanstack/react-query"
import { useNavigate } from "react-router-dom"
import type { RegisterData } from "../schemas"
import { authApi } from "../api"
import { handleQueryFn } from "@lib"
import type { CustomerAccount, ProblemDetails } from "@types"
import useAccount from "./useAccount"

const useRegister = () => {
  const navigate = useNavigate()
  const { setAccount } = useAccount()

  return useMutation<CustomerAccount, ProblemDetails, RegisterData>({
    mutationFn: (data: RegisterData) =>
      handleQueryFn(() => authApi.register(data)),
    onSuccess: (account) => {
      setAccount(account)
      navigate("/")
    },
    onError: () => {
      console.log("fail")
      setAccount(null)
    },
  })
}

export default useRegister
