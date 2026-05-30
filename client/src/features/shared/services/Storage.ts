export const LocalStorage = {
  getItems: <T>(key: string): T[] => {
    const raw = localStorage.getItem(key)

    if (!raw) {
      return []
    }

    try {
      return JSON.parse(raw)
    } catch {
      localStorage.removeItem(key)
      return []
    }
  },

  setItems: <T>(key: string, items: T[]): boolean => {
    try {
      localStorage.setItem(key, JSON.stringify(items))
      return true
    } catch (error) {
      console.warn(`Failed to save to localStorage key "${key}"`, error)
      return false
    }
  },

  clear: (key: string): boolean => {
    try {
      localStorage.removeItem(key)
      return true
    } catch (error) {
      console.warn(`Failed to clear localStorage key "${key}"`, error)
      return false
    }
  },
}
