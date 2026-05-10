export const Availability = {
  OutOfStock: 1 << 0,
  InStock: 1 << 1,
  All: (1 << 0) | (1 << 1),
} as const

export type Availability = (typeof Availability)[keyof typeof Availability]

export enum PreviewType {
  None = -1,
  Color = 0,
  Image = 1,
}
