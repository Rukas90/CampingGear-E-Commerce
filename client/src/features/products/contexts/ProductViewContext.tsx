import { createContext, useContext, useEffect, useMemo } from "react"
import useProduct from "../hooks/useProduct"
import type {
  ProductImageUrl,
  ProductSku,
  ProductDetail,
  OptionId,
} from "@types"
import { useNavigate, useSearchParams } from "react-router-dom"
import { arraysEqual } from "@utils"

interface ProductViewData {
  isPending: boolean
  data: ProductDetail | undefined
  sku: ProductSku | undefined
  images: ProductImageUrl[] | undefined
  optionChanged: (id: OptionId) => void
  availableOptionIds: Set<OptionId>
}

const ProductViewContext = createContext<ProductViewData | undefined>(undefined)

interface ProductViewProps extends React.PropsWithChildren {
  slug: string
}

export const ProductViewProvider = ({ slug, children }: ProductViewProps) => {
  const { data, isPending } = useProduct(slug)
  const [searchParams, setSearchParams] = useSearchParams()

  const navigate = useNavigate()

  const getSku = (code: string | undefined | null): ProductSku | undefined =>
    data?.skus.find((sku) => sku.code === code)

  if (!data && !isPending) {
    navigate("not-found")
    return
  }

  const sku = getSku(searchParams.get("variant"))
  const selectedOptions = sku?.optionIds ?? []

  const images = useMemo(
    () =>
      data?.images
        .sort((a, b) => (b.optionId ? 1 : 0) - (a.optionId ? 1 : 0))
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
      selectVariant(data.skus[0].code)
    } else if (currentSku) {
      selectVariant(currentSku.code)
    }
  }, [data])

  const selectVariant = (code: string) => {
    setSearchParams(
      (params) => {
        params.set("variant", code)
        return params
      },
      { replace: true },
    )
  }

  const optionChanged = (id: OptionId) => {
    const newSelectedOptionIds = getNewSelectedOptions(id)

    if (!newSelectedOptionIds || !data) {
      return
    }

    const sku = data.skus.find((sku) =>
      arraysEqual(sku.optionIds, newSelectedOptionIds),
    )

    if (!sku) {
      return
    }
    selectVariant(sku.code)
  }

  const getNewSelectedOptions = (id: OptionId) => {
    if (!data) {
      return
    }
    const idGroup = data.options.find((group) =>
      group.options.find((option) => option.id === id),
    )

    if (!idGroup) {
      return
    }
    const newSelectedOptionIds = [...selectedOptions]
    const currentSelectedGroupOptionId = idGroup.options.find((option) =>
      newSelectedOptionIds.includes(option.id),
    )
    if (currentSelectedGroupOptionId) {
      const oldIdIndex = newSelectedOptionIds.indexOf(
        currentSelectedGroupOptionId.id,
      )
      newSelectedOptionIds.splice(oldIdIndex, 1)
    }
    newSelectedOptionIds.push(id)
    return newSelectedOptionIds
  }

  const getAvailableOptionIds = (): Set<OptionId> => {
    if (!data) {
      return new Set()
    }

    return new Set(
      data.options.flatMap((group) =>
        group.options
          .filter((option) => {
            const otherGroupsSelected = selectedOptions.filter(
              (selId) => !group.options.some((o) => o.id === selId),
            )

            return data.skus.some(
              (sku) =>
                sku.optionIds.includes(option.id) &&
                otherGroupsSelected.every((selId) =>
                  sku.optionIds.includes(selId),
                ),
            )
          })
          .map((o) => o.id),
      ),
    )
  }

  const availableOptionIds = useMemo(
    () => getAvailableOptionIds(),
    [data, selectedOptions],
  )

  return (
    <ProductViewContext.Provider
      value={{
        isPending,
        data,
        sku,
        images,
        optionChanged,
        availableOptionIds,
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
