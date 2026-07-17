import { FoldoutContent, Line } from "@components"
import NavMenuItem from "./NavMenuItem"
import { useApp, useCategories, useCategoryGroups } from "@features"
import { Link } from "react-router-dom"
import clsx from "clsx"

const MobileSideMenu = () => {
  const { menu } = useApp()
  const { data: categories } = useCategories()
  const { data: groups } = useCategoryGroups()

  return (
    <ul
      className={clsx(
        "flex flex-col gap-3 lg:hidden dark:text-stone-200 fixed top-0 px-6 py-12 h-[calc(100%-73px)] w-72 max-w-full bg-white shadow-2xl z-64 mt-18.25 transition-all",
        menu.isOpened && "left-0",
        !menu.isOpened && "-left-full",
      )}
    >
      <FoldoutContent
        labelClassName="text-base flex gap-1.5 items-center font-normal"
        label="Products"
        opened
      >
        <ul className="flex flex-col gap-3 mt-2">
          {groups?.map((group, index) => {
            return (
              <div key={group.slug}>
                <FoldoutContent
                  label={group.name}
                  labelClassName="text-sm pl-4 font-normal"
                  opened
                >
                  <ul className="flex flex-col gap-2.5 mt-0.5">
                    {categories
                      ?.filter((category) => category.groupSlug === group.slug)
                      .map((category) => (
                        <Link
                          to={`/products/${category.slug}`}
                          key={category.slug}
                        >
                          <NavMenuItem className="group text-sm pl-8 cursor-pointer">
                            <p className="group-hover:translate-x-2 text-neutral-700 group-hover:text-neutral-900 transition-transform will-change-transform">
                              {category.name}
                            </p>
                          </NavMenuItem>
                        </Link>
                      ))}
                  </ul>
                </FoldoutContent>
                {index < groups.length - 1 && <Line className="mt-3" />}
              </div>
            )
          })}
        </ul>
      </FoldoutContent>
      <Line className="bg-neutral-200" />
      <NavMenuItem className="text-sm">Help</NavMenuItem>
      <Line className="bg-neutral-200" />
      <NavMenuItem className="text-sm">About</NavMenuItem>
      <Line className="bg-neutral-200" />
      <NavMenuItem className="text-sm">Profile</NavMenuItem>
      <Line className="bg-neutral-200" />
      <NavMenuItem className="text-sm">Orders</NavMenuItem>
    </ul>
  )
}
export default MobileSideMenu
