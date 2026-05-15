export type Brand<T, Name extends string> = T & { readonly _brand: Name }

export type ReviewId = Brand<string, "Review">
export type CustomerId = Brand<string, "Customer">
export type CategoryId = Brand<string, "Category">
export type ProductId = Brand<string, "Product">
export type CartItemId = Brand<string, "CartItem">
export type SkuId = Brand<string, "Sku">
export type OptionId = Brand<string, "Option">

export type SkuCode = Brand<string, "SkuCode">
