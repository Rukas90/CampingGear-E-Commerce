export type Brand<T, Name extends string> = T & { readonly _brand: Name }

export type CustomerId = Brand<string, "Customer">
export type ProductId = Brand<string, "Product">
export type CartItemId = Brand<string, "CartItem">
export type SkuId = Brand<string, "Sku">
