import { IconMountain, Spinner } from "@features"

const AppStartingPage = () => {
  return (
    <div className="flex flex-col gap-6 justify-center items-center w-dvw h-dvh text-center sm:p-8 p-4 bg-stone-50">
      <IconMountain className="size-12" />
      <p className="sm:text-4xl text-3xl font-semibold uppercase">
        Please wait...
      </p>
      <p className="sm:text-base text-sm">
        Due to a cold start, the server needs a moment to spin up. Please wait a
        minute.
      </p>
      <Spinner className="size-8 mt-4" />
    </div>
  )
}
export default AppStartingPage
