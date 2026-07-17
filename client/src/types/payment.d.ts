import type { PaymentStatus } from "./enums"
import type { PaymentAttemptId, PaymentId } from "./brands"

export type Payment = {
  paymentId: PaymentId
  isComplete: boolean
  clientSecret: string
  attemptsRemaining: number
}

export type PaymentAttempt = {
  attemptId: PaymentAttemptId
}

export type PaymentAttemptStatus = {
  status: PaymentStatus
}

export type PaymentStatusType =
  (typeof PaymentStatus)[keyof typeof PaymentStatus]
