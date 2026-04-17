function storageGet<T>(key: string): T | null {
  try {
    const raw = localStorage.getItem(key)
    return raw ? (JSON.parse(raw) as T) : null
  } catch {
    return null
  }
}

function storageSet<T>(key: string, value: T): void {
  try {
    localStorage.setItem(key, JSON.stringify(value))
  } catch {
    // storage full or unavailable (e.g. SSR, private mode)
  }
}

function storageRemove(key: string): void {
  try {
    localStorage.removeItem(key)
  } catch {}
}

export const storage = {
  get: storageGet,
  set: storageSet,
  remove: storageRemove,
}
