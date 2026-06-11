import type { ApiResult } from "@types"
import { useEffect, useRef, useState } from "react"
import { useFormState } from "./useFormState"
import { useManagedMutation } from "./useManagedMutation"
import type { ErrorPool } from "./useErrorPool"

export type ErrorKeyMapper = (key: string) => string

export type FieldInterface<TFieldType> = {
  value: <TKey extends keyof TFieldType>(
    key: TKey,
  ) => TFieldType[TKey] | undefined
  update: <TKey extends keyof TFieldType>(
    key: TKey,
    val: TFieldType[TKey],
  ) => void
  error: <TKey extends keyof TFieldType>(key: TKey) => string | undefined
  hasError: <TKey extends keyof TFieldType>(key: TKey) => boolean
  isTouched: <TKey extends keyof TFieldType>(key: TKey) => boolean
  isDirty: <TKey extends keyof TFieldType>(key: TKey) => boolean
  commit: () => void
}

export type ValueInterface<T> = {
  value: () => T
  update: (val: T) => void
  error: () => string | undefined
  hasError: () => boolean
  isTouched: () => boolean
  isDirty: () => boolean
  commit: () => void
}

export interface UseDataProps<TData, TResponse> {
  data?: TData
  defaultData: TData
  mutationKey: string[]
  requestFunc: (data: TData) => Promise<ApiResult<TResponse>>
  onMutationSuccess?: (response: TResponse | undefined) => void
  errorPool: ErrorPool
  errorKeyMappers?: ErrorKeyMapper[]
}

export interface UseDataSnapshot {
  makeSnapshot: () => void
  revertToSnapshot: () => void
}

export const useData = <TData, TResponse = unknown>({
  data,
  defaultData,
  mutationKey,
  requestFunc,
  onMutationSuccess,
  errorPool,
  errorKeyMappers,
}: UseDataProps<TData, TResponse>) => {
  const [internalData, setInternalData] = useState<TData>(data ?? defaultData)
  const [cachedResponse, setCachedResponse] = useState<TResponse | undefined>()

  const snapshot = useRef<TData>(undefined)
  const formState = useFormState(internalData)

  const { commitWith, isPending } = useManagedMutation<TData, TResponse>({
    mutationKey,
    requestFunc,
    onSuccess: (response) => {
      formState.reset()
      onMutationSuccess?.(response)
      setCachedResponse(response)
    },
    onError: (errors) => {
      errorPool.setErrors(errors)
    },
  })

  useEffect(() => {
    if (data) {
      overrideData(data)
    }
  }, [data])

  const overrideData = (data: TData) => {
    setInternalData(data)
    formState.reset()
  }

  const commit = () => {
    if (!formState.isAnyDirty()) {
      return
    }
    commitWith(internalData)
  }

  const findError = (key: string | number | symbol): string | undefined => {
    const errorKey = String(key)

    if (!errorKeyMappers) {
      return errorPool.getError(errorKey)
    }

    for (const mapper of errorKeyMappers) {
      const error = errorPool.getError(mapper(errorKey))
      if (error) return error
    }

    return undefined
  }

  const clearError = (key: string | number | symbol) => {
    const errorKey = String(key)

    if (!errorKeyMappers) {
      errorPool.clearError(errorKey)
      return
    }

    errorKeyMappers.forEach((mapper) => {
      errorPool.clearError(mapper(errorKey))
    })
  }

  const asField = (): FieldInterface<TData> => ({
    value: (key) => internalData[key],
    error: (key) => findError(key),
    hasError: (key) => !!findError(key),
    isTouched: (key) => formState.isTouched(String(key)),
    isDirty: (key) => formState.isDirty(String(key)),
    update: (key, val) => {
      formState.markTouched(String(key))
      formState.markRootDirty(key, val)

      clearError(key)
      setInternalData((prev) => ({ ...prev, [key]: val }))
    },
    commit,
  })

  const field = <TField extends keyof TData>(fieldKey: TField) => {
    type FieldType = NonNullable<TData[TField]>
    const fk = String(fieldKey)

    return {
      value: <TKey extends keyof FieldType>(
        key: TKey,
      ): FieldType[TKey] | undefined => {
        const fieldData = internalData[fieldKey]
        return fieldData && typeof fieldData === "object"
          ? (fieldData as FieldType)[key]
          : undefined
      },
      error: (key: keyof FieldType) => findError(key),
      hasError: (key: keyof FieldType) => !!findError(key),
      isTouched: (key: keyof FieldType) =>
        formState.isTouched(formState.toKey(fk, String(key))),
      isDirty: (key: keyof FieldType) =>
        formState.isDirty(formState.toKey(fk, String(key))),
      update: <TKey extends keyof FieldType>(
        key: TKey,
        val: FieldType[TKey],
      ) => {
        formState.markKeyTouched(fk, String(key))
        formState.markKeyDirty(fieldKey, String(key), val)

        clearError(key)
        setInternalData((prev) => ({
          ...prev,
          [fieldKey]: { ...(prev[fieldKey] as object), [key]: val },
        }))
      },
      commit,
    } satisfies FieldInterface<FieldType>
  }

  const value = <TField extends keyof TData>(fieldKey: TField) => {
    const fk = String(fieldKey)

    return {
      value: () => internalData[fieldKey],
      error: () => findError(fk),
      hasError: () => !!findError(fk),
      isTouched: () => formState.isTouched(fk),
      isDirty: () => formState.isDirty(fk),
      update: (val: TData[TField]) => {
        formState.markTouched(fk)
        formState.markRootDirty(fieldKey, val)

        clearError(fk)
        setInternalData((prev) => ({ ...prev, [fieldKey]: val }))
      },
      commit,
    } satisfies ValueInterface<TData[TField]>
  }

  const self = (): ValueInterface<TData> => ({
    value: () => internalData,
    update: (val: TData) => {
      formState.markRootDirty("self" as keyof TData, val)
      setInternalData(val)
    },
    error: () => findError("self" as keyof TData),
    hasError: () => !!findError("self" as keyof TData),
    isTouched: () => formState.isTouched("self"),
    isDirty: () => formState.isDirty("self"),
    commit,
  })

  const makeSnapshot = () => {
    snapshot.current = internalData
  }

  const revertToSnapshot = () => {
    if (snapshot.current) {
      setInternalData(snapshot.current)
    }
    formState.reset()
    errorPool.clear()
  }

  return {
    data: internalData,
    makeSnapshot,
    revertToSnapshot,
    overrideData,
    cachedResponse,
    value,
    self,
    field,
    asField,
    isMutating: isPending,
    commit,
    isDirty: formState.isAnyDirty,
  }
}
