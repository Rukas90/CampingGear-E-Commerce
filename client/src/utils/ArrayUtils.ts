export const arraysEqual = <T>(a: T[], b: T[]) =>
  a.length === b.length && a.every((val) => b.includes(val))
