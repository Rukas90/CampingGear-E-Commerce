import {
  Button,
  GoogleButton,
  HorizontalLineLabel,
  LabeledInputField,
  PageWrapper,
  Spinner,
} from "@components"
import { Link } from "react-router-dom"
import { useForm } from "react-hook-form"
import { zodResolver } from "@hookform/resolvers/zod"
import { LoginSchema, useLogin, type LoginData } from "@features"

const LoginPage = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginData>({
    resolver: zodResolver(LoginSchema),
  })
  const { mutate, isPending, error } = useLogin()

  const onSubmit = async (data: LoginData) => {
    if (isPending) return
    mutate(data)
  }

  return (
    <PageWrapper className="flex items-center flex-col w-full py-8">
      <p className="font-medium text-5xl text-center font-serif">
        Your Account
      </p>
      <p className="mt-4 text-lg mb-2">
        Don't have an account?{" "}
        <Link to="/register">
          <span className="underline text-lime-800">Register</span>
        </Link>
      </p>
      <div className="flex flex-col w-full max-w-xs">
        <form onSubmit={handleSubmit(onSubmit)}>
          <LabeledInputField
            id="email"
            parentClassName="mt-4"
            className="w-full text-base!"
            {...register("email")}
            error={errors.email?.message}
          />
          <LabeledInputField
            id="password"
            parentClassName="mt-4"
            className="w-full text-base!"
            {...register("password")}
            error={errors.password?.message}
            isHidden
            isHideable
          />
          <Button
            className="mt-4 w-full flex justify-center items-center h-10"
            style="contrast"
            type="submit"
            disabled={isPending}
          >
            {!isPending && <span>Sign in</span>}
            {isPending && <Spinner className="size-5 text-white" />}
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
export default LoginPage
