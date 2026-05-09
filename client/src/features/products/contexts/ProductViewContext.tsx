import { createContext, useContext, useEffect, useMemo, useState } from "react"
import useProduct from "../hooks/useProduct"
import type {
  OptionId,
  ProductImageUrl,
  ProductSku,
  ProductDetail,
} from "@types"
import { useNavigate, useSearchParams } from "react-router-dom"
import { usePageTitle } from "@features"

interface ProductViewData {
  isPending: boolean
  data: ProductDetail | undefined
  sku: ProductSku | undefined
  images: ProductImageUrl[] | undefined
}

const ProductViewContext = createContext<ProductViewData | undefined>(undefined)

interface ProductViewProps extends React.PropsWithChildren {
  slug: string
}

export const ProductViewProvider = ({ slug, children }: ProductViewProps) => {
  const { data, isPending } = useProduct(slug)

  const [searchParams, setSearchParams] = useSearchParams()
  const [selectedOptions, setSelectedOptions] = useState<OptionId[]>([])

  const navigate = useNavigate()

  const images = useMemo(
    () =>
      data?.images
        .filter(
          (image) =>
            !image.optionId ||
            selectedOptions.findIndex((id) => id === image.optionId) !== -1,
        )
        .flatMap((img) => img.urls),
    [data, selectedOptions],
  )

  useEffect(() => {
    const variantParam = searchParams.get("variant")
    const currentSku = getSku(variantParam)

    if (!currentSku && data) {
      selectVariant(data.skus[0].codeHash)
    } else if (currentSku) {
      selectVariant(currentSku.codeHash)
    }
  }, [data])

  const selectVariant = (codeHash: string) => {
    setSearchParams(
      (params) => {
        params.set("variant", codeHash)
        return params
      },
      { replace: true },
    )
    const currentSku = getSku(codeHash)
    setSelectedOptions(currentSku?.optionIds ?? [])
  }

  const getSku = (
    codeHash: string | undefined | null,
  ): ProductSku | undefined =>
    data?.skus.find((sku) => sku.codeHash === codeHash)

  if (!data && !isPending) {
    navigate("not-found")
    return
  }

  const sku = getSku(searchParams.get("variant"))

  return (
    <ProductViewContext.Provider
      value={{
        isPending,
        data,
        sku,
        images,
      }}
    >
      {children}
    </ProductViewContext.Provider>
  )
}

export const useProductView = () => {
  const context = useContext(ProductViewContext)

  if (!context) {
    throw new Error(
      "Can only use useProductView within the ProductViewProvider!",
    )
  }
  return context
}
