import {
  Button,
  GoogleButton,
  HorizontalLineLabel,
  LabeledInputField,
  PageWrapper,
} from "@components"
import { Link } from "react-router-dom"
import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { RegisterSchema, useRegister, type RegisterData } from "@features"

const RegisterPage = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterData>({
    resolver: zodResolver(RegisterSchema),
  })
  const { mutate, isPending, error } = useRegister()

  const onSubmit = async (data: RegisterData) => {
    if (isPending) return
    mutate(data)
  }

  return (
    <PageWrapper className="flex items-center flex-col w-full py-8">
      <p className="font-medium text-5xl text-center font-serif">
        Your Account
      </p>
      <p className="mt-4 text-lg mb-2">
        Already have an account?{" "}
        <Link to="/login">
          <span className="underline text-lime-800">Login</span>
        </Link>
      </p>
      <div className="flex flex-col w-full max-w-xs">
        <form onSubmit={handleSubmit(onSubmit)}>
          <LabeledInputField
            id="email"
            parentClassName="mt-4"
            className="w-full"
            error={errors.email?.message}
            {...register("email")}
          />
          <LabeledInputField
            id="password"
            parentClassName="mt-4"
            className="w-full"
            error={errors.password?.message}
            {...register("password")}
            isHidden
            isHideable
          />
          <LabeledInputField
            id="confirm_password"
            parentClassName="mt-4"
            className="w-full"
            error={errors.confirmPassword?.message}
            {...register("confirmPassword")}
            isHidden
            isHideable
          />
          <Button className="mt-4 w-full" style="contrast" type="submit">
            Register
          </Button>
        </form>
        {error && (
          <div className="relative px-2.5 py-4 border-2 rounded-lg border-red-800 mt-6">
            <p className="absolute top-0 -translate-y-1/2 left-6 bg-neutral-50 px-2 font-medium text-red-800">
              Error
            </p>
            <p className="text-red-800 text-center">
              {error?.errors[0]?.reason}
            </p>
          </div>
        )}
        <HorizontalLineLabel>OR</HorizontalLineLabel>
        <GoogleButton />
      </div>
    </PageWrapper>
  )
}
export default RegisterPage
