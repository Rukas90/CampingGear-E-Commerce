import { FoldoutContent } from "@features"

interface FooterNavigationSectionProps {
  header: string
  items: { name: string; link?: string }[]
}

const FooterNavigationSection = ({
  header,
  items,
}: FooterNavigationSectionProps) => {
  return (
    <div>
      <FoldoutContent
        label={header}
        labelClassName="playfair-display text-lg font-semibold text-start"
        opened
      >
        <ul className="mt-2 grid flex-col gap-2 text-base">
          {items.map((item) => (
            <li
              key={item.name}
              className="text-stone-700 hover:text-stone-500 active:text-stone-900 cursor-pointer text-start"
            >
              {item.name}
            </li>
          ))}
        </ul>
      </FoldoutContent>
    </div>
  )
}
export default FooterNavigationSection
