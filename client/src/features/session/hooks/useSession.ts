import { useQueryClient } from "@tanstack/react-query"

const useSession = () => {
  const queryClient = useQueryClient()

  const invalidate = async () => {
    await queryClient.invalidateQueries({ queryKey: ["cart"] })
    await queryClient.invalidateQueries({ queryKey: ["cart-summary"] })
    await queryClient.invalidateQueries({ queryKey: ["wishlist"] })
  }

  return {
    invalidate,
  }
}
export default useSession
