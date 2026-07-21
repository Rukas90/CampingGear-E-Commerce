import { createAsyncStoragePersister } from "@tanstack/query-async-storage-persister"
import { QueryClient } from "@tanstack/react-query"
import { PersistQueryClientProvider } from "@tanstack/react-query-persist-client"
import { BrowserRouter } from "react-router-dom"
import { get, set, del } from "idb-keyval"
import {
  AppProvider,
  AuthProvider,
  CartProvider,
  WishlistProvider,
} from "@features"
import "react-loading-skeleton/dist/skeleton.css"

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: 1000 * 60 * 5,
      gcTime: 1000 * 60 * 30,
    },
  },
})

const persister = createAsyncStoragePersister({
  storage: {
    getItem: (key) => get(key),
    setItem: (key, value) => set(key, value),
    removeItem: (key) => del(key),
  },
})

const AppProviders = ({ children }: React.PropsWithChildren) => {
  return (
    <PersistQueryClientProvider
      client={queryClient}
      persistOptions={{
        persister,
        buster: "v1",
        dehydrateOptions: {
          shouldDehydrateQuery: (query) =>
            [
              "categories",
              "category-groups",
              "countries",
              "country-shipping-methods",
            ].includes(query.queryKey[0] as string),
        },
      }}
    >
      <AuthProvider>
        <CartProvider>
          <WishlistProvider>
            <BrowserRouter>
              <AppProvider>{children}</AppProvider>
            </BrowserRouter>
          </WishlistProvider>
        </CartProvider>
      </AuthProvider>
    </PersistQueryClientProvider>
  )
}
export default AppProviders
