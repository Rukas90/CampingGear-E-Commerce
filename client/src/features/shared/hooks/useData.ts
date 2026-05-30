import type { ApiResult } from "@types"
import { useEffect, useRef, useState } from "react"
import { useFormState } from "./useFormState"
import { useManagedMutation } from "./useManagedMutation"

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
}

export const useData = <TData, TResponse = unknown>({
  data,
  defaultData,
  mutationKey,
  requestFunc,
}: UseDataProps<TData, TResponse>) => {
  const [internalData, setInternalData] = useState<TData>(data ?? defaultData)
  const [isEditing, setEditing] = useState(false)

  const snapshot = useRef<TData>(undefined)

  const formState = useFormState(internalData)

  const { commitWith, errors, isPending } = useManagedMutation<
    TData,
    TResponse
  >({
    mutationKey,
    requestFunc,
    onSuccess: () => {
      formState.reset()
      setEditing(false)
    },
  })

  useEffect(() => {
    if (data) {
      setInternalData(data)
      formState.reset()
    }
  }, [data])

  const commit = () => {
    if (!formState.isAnyDirty()) {
      return
    }
    commitWith(internalData)
  }

  const asField = (): FieldInterface<TData> => ({
    value: (key) => internalData[key],
    error: (key) => errors.getError(key),
    hasError: (key) => !!errors.getError(key),
    isTouched: (key) => formState.isTouched(errors.errorKey(key)),
    isDirty: (key) => formState.isDirty(errors.errorKey(key)),
    update: (key, val) => {
      formState.markTouched(errors.errorKey(key))
      formState.markRootDirty(key, val)
      errors.clearError(errors.errorKey(key))

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
      error: (key: keyof FieldType) => errors.getNestedError(fk, key),
      hasError: (key: keyof FieldType) => !!errors.getNestedError(fk, key),
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
        errors.clearError(errors.errorKey(key))

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
      error: () => errors.getError(fieldKey),
      hasError: () => !!errors.getError(fieldKey),
      isTouched: () => formState.isTouched(fk),
      isDirty: () => formState.isDirty(fk),
      update: (val: TData[TField]) => {
        formState.markTouched(fk)
        formState.markRootDirty(fieldKey, val)
        errors.clearError(errors.errorKey(fieldKey))

        setInternalData((prev) => ({ ...prev, [fieldKey]: val }))
      },
      commit,
    } satisfies ValueInterface<TData[TField]>
  }

  const edit = () => {
    snapshot.current = internalData
    setEditing(true)
  }

  const cancel = () => {
    if (snapshot.current) {
      setInternalData(snapshot.current)
    }
    formState.reset()
    errors.clear()
    setEditing(false)
  }

  const toggleEdit = () => {
    if (isEditing) {
      cancel()
      return
    }
    edit()
  }

  return {
    data: internalData,
    value,
    field,
    asField,
    isMutating: isPending,
    isEditing,
    edit,
    cancel,
    toggleEdit,
    commit,
    isDirty: formState.isAnyDirty,
  }
}
