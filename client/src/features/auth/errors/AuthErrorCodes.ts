export const AuthErrorCodes = {
  AUTH_UNAUTHENTICATED: "auth.unauthenticated",
} as const
export type AuthErrorCode = (typeof AuthErrorCodes)[keyof typeof AuthErrorCodes]
