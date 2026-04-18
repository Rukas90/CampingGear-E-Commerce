const ContentContainer = ({ children }: React.PropsWithChildren) => {
  return (
    <div className="w-full h-full mt-20 flex flex-col flex-1">{children}</div>
  )
}
export default ContentContainer
