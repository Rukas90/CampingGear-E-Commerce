import { makeRequest } from "@lib"
import type {
  CheckoutForm,
  UpdateCheckoutContactRequest,
  PostalAddress,
  CheckoutBilling,
  ShippingMethodId,
  CheckoutShipping,
  CheckoutStats,
  CheckoutConfirmation,
} from "@types"

const checkoutApi = {
  init: async () => await makeRequest(`api/v1/checkout`, "post"),

  getForm: async () =>
    await makeRequest<CheckoutForm>(`api/v1/checkout/form`, "get"),

  updateContact: async (contact: UpdateCheckoutContactRequest) =>
    await makeRequest<string>(`api/v1/checkout/contact`, "patch", contact),

  updateShippingAddress: async (address: PostalAddress) =>
    await makeRequest<CheckoutShipping>(
      `api/v1/checkout/shipping-address`,
      "patch",
      address,
    ),

  updateShippingMethod: async (methodId: ShippingMethodId | undefined) =>
    await makeRequest<string>(`api/v1/checkout/shipping-method`, "patch", {
      shippingMethodId: methodId,
    }),

  updateBilling: async (billing: CheckoutBilling) =>
    await makeRequest<string>(`api/v1/checkout/billing`, "patch", billing),

  getStats: async () =>
    await makeRequest<CheckoutStats>(`api/v1/checkout/stats`),

  confirmCheckout: async (saveInformation: boolean) =>
    await makeRequest<CheckoutConfirmation>(`api/v1/checkout/confirm`, "post", {
      saveInformation: saveInformation,
    }),
}
export default checkoutApi
