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
      <p className="playfair-display text-lg font-semibold xl:text-start text-center">
        {header}
      </p>
      <ul className="mt-2 grid flex-col gap-2 text-base">
        {items.map((item) => (
          <li className="text-stone-700 hover:text-stone-500 active:text-stone-900 cursor-pointer xl:text-start text-center">
            {item.name}
          </li>
        ))}
      </ul>
    </div>
  )
}
export default FooterNavigationSection
