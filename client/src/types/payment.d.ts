import type { PaymentStatus } from "./enums"
import type { PaymentAttemptId } from "./id"

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
