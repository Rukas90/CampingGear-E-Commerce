import { makeRequest } from "@lib"
import { useQuery } from "@tanstack/react-query"
import type { Category } from "@types"

const useCategories = () => {
  const { data } = useQuery({
    queryKey: ["categories"],
    queryFn: async () => {
      const res = await makeRequest<Category[]>("api/v1/category")
      if (!res.isSuccess) throw res.error
      return res.data
    },
  })
  return { data }
}
export default useCategories

/*
    [Listing Categories/Collections]:

        /categories/backpacks
        /categories/sleeping-bags
        /categories/handheld-gps
        /categories/tents

    [Listing Filtered]:

        /categories/handheld-gps?brand=garmin&page=1
        /categories/sleeping-bags?option=zip:left&option=color:green&page=1
        /categories/boots?option=size:m&page=5
        /categories/backpacks?option=torso-height:short&option=color:blue&page=2

    [Product Detail]:

        /products/garmin-gpsmap-67?...
        /products/western-mountaineering-summer-lite?...
        /products/hyperlite-mountain-gear-versa?...
        /products/gregory-baltoro-75?...

    [Types]:

        /brands
        /categories
*/
