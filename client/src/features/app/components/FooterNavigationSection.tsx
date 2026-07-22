import { FoldoutContent } from "@features"
import { Link } from "react-router-dom"

interface FooterNavigationSectionProps {
  header: string
  items: { name: string; link?: string }[]
}

const FooterNavigationSection = ({
  header,
  items,
}: FooterNavigationSectionProps) => {
  const renderItems = () => (
    <ul className="mt-2 grid flex-col gap-2 text-base">
      {items.map((item) => (
        <Link to={item.link ?? "#"}>
          <li
            key={item.name}
            className="text-stone-700 hover:text-stone-500 active:text-stone-900 cursor-pointer text-start"
          >
            {item.name}
          </li>
        </Link>
      ))}
    </ul>
  )

  return (
    <div>
      <div className="xl:block hidden">
        <p className="playfair-display text-lg font-semibold text-start">
          {header}
        </p>
        {renderItems()}
      </div>
      <FoldoutContent
        label={header}
        className="xl:hidden"
        labelClassName="playfair-display text-lg font-semibold text-start"
        opened
      >
        {renderItems()}
      </FoldoutContent>
    </div>
  )
}
export default FooterNavigationSection
