import Skeleton, { type SkeletonProps } from "react-loading-skeleton"

type BaseTextProps<C extends React.ElementType> = {
  as?: C
  showSkeleton?: boolean
  skeleton?: SkeletonProps
}

type TextProps<C extends React.ElementType> = BaseTextProps<C> &
  Omit<React.ComponentPropsWithoutRef<C>, keyof BaseTextProps<C>>

const Text = <C extends React.ElementType = "p">({
  as,
  showSkeleton,
  skeleton,
  children,
  ...props
}: TextProps<C>) => {
  const Component = as || "p"

  if (showSkeleton) {
    return <Skeleton {...skeleton} />
  }
  return <Component {...props}>{children}</Component>
}

export default Text
