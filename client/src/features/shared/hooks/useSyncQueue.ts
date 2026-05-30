import { useCallback, useEffect, useRef } from "react"

interface UseSyncQueueProps<TData> {
  delayMs?: number
  onSync: (snapshot: TData) => void
}

export const useSyncQueue = <TData>({
  delayMs = 1000,
  onSync,
}: UseSyncQueueProps<TData>) => {
  const timerRef = useRef<ReturnType<typeof setTimeout> | null>(null)
  const pendingRef = useRef<TData | null>(null)
  const onSyncRef = useRef(onSync)

  useEffect(() => {
    onSyncRef.current = onSync
  }, [onSync])

  const flush = useCallback(() => {
    if (pendingRef.current === null) return
    onSyncRef.current(pendingRef.current)
    pendingRef.current = null
  }, [])

  const cancel = useCallback(() => {
    if (timerRef.current) clearTimeout(timerRef.current)
    pendingRef.current = null
  }, [])

  const queue = useCallback(
    (snapshot: TData) => {
      console.log("queue snapshot: ", JSON.stringify(snapshot))
      pendingRef.current = snapshot
      if (timerRef.current) clearTimeout(timerRef.current)
      timerRef.current = setTimeout(flush, delayMs)
    },
    [flush, delayMs],
  )

  const flushNow = useCallback(() => {
    if (timerRef.current) clearTimeout(timerRef.current)
    flush()
  }, [flush])

  useEffect(() => {
    return () => {
      if (timerRef.current) clearTimeout(timerRef.current)
      flush()
    }
  }, [flush])

  return { queue, flushNow, cancel }
}
