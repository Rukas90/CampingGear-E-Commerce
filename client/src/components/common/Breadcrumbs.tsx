type BreadcrumbLink = {
  name: string
  link: string
  disabled?: boolean
}
interface BreadcrumbsProps {
  items?: BreadcrumbLink[]
}
const Breadcrumbs = ({ items }: BreadcrumbsProps) => {
  return (
    <p className="text-sm mb-4 space-x-2 font-medium">
      {items?.map((item, index) => (
        <span key={item.link}>
          {item.disabled ? (
            <span className="text-neutral-600">{item.name}</span>
          ) : (
            <a href={item.link} className="hover:text-lime-800">
              {item.name}
            </a>
          )}
          {index < items.length - 1 && <span> /</span>}
        </span>
      ))}
    </p>
  )
}
export default Breadcrumbs
