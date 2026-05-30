interface PageTitleProps {
  title: string
}
const usePageTitle = ({ title }: PageTitleProps) => {
  document.title = title
}
export default usePageTitle
