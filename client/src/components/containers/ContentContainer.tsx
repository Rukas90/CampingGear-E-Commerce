const ContentContainer = ({ children }: React.PropsWithChildren) => {
  return (
    <div className="w-full h-full mt-18 flex flex-col bg-amber-700">
      {children}
    </div>
  )
}
export default ContentContainer
