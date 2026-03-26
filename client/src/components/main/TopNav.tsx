import {
  IconAccount,
  IconArrow,
  IconCart,
  IconSaved,
  IconSearch,
  InputField,
  LogoWithText,
  PageWrapper,
} from "@components"

const TopNav = () => {
  return (
    <nav className="fixed dark:bg-stone-950 bg-white w-full py-4 h-20 z-64">
      <PageWrapper>
        <div className="flex items-center justify-between w-full">
          <ul className="flex gap-5 w-1/3 dark:text-stone-200">
            <li className="font-medium flex gap-1.5 items-center">
              Products <IconArrow className="rotate-90 size-4" />
            </li>
            <li className="font-medium">Help</li>
            <li className="font-medium">About</li>
          </ul>
          <div className="flex items-center justify-center w-1/3">
            <LogoWithText />
          </div>
          <div className="flex gap-5 items-center justify-end w-1/3">
            <div className="relative size-5">
              <IconSearch className="size-full dark:text-stone-100 text-stone-800 z-1 relative " />
              <InputField
                className="rounded-xl absolute right-full translate-x-7.5 top-1/2 -translate-y-1/2"
                placeholder="Search ..."
              />
            </div>

            <IconAccount className="size-5 dark:text-stone-100 text-stone-800" />
            <IconSaved className="size-5 dark:text-stone-100 text-stone-800" />
            <div className="relative">
              <IconCart className="size-5 dark:text-stone-100 text-stone-800" />
              <span className="absolute bg-[#000000] inter text-stone-200 text-[11px] font-semibold min-w-3.75 h-3.75 p-1 rounded-full flex items-center justify-center outline-2 outline-white -right-2 -top-2">
                0
              </span>
            </div>
          </div>
        </div>
      </PageWrapper>
    </nav>
  )
}
export default TopNav
