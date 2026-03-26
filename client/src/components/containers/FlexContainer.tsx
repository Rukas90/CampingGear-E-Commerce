type Justify = "start" | "between" | "center" | "around" | "end"
// rest ...

interface FlexContainerProps extends React.ComponentProps<"div"> {
  justify?: Justify
}
const FlexContainer = ({ justify }: FlexContainerProps) => {}

export default FlexContainer
