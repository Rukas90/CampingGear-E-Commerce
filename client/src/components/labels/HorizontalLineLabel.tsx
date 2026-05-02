interface HorizontalLineLabelProps extends React.PropsWithChildren {}

const HorizontalLineLabel = ({ children }: HorizontalLineLabelProps) => {
  return (
    <div className="flex gap-4 my-4 items-center">
      <div className="w-full h-px bg-stone-200" />
      <p className="text-center text-sm text-stone-600 font-medium">
        {children}
      </p>
      <div className="w-full h-px bg-stone-200" />
    </div>
  )
}
export default HorizontalLineLabel
