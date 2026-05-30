import { makeRequest } from "@lib"
import type {
  CheckoutForm,
  Checkout,
  CheckoutContact,
  PostalAddress,
  CheckoutBilling,
} from "@types"

const checkoutApi = {
  checkout: async () => await makeRequest<Checkout>(`api/v1/checkout`, "post"),

  getCheckoutForm: async () =>
    await makeRequest<CheckoutForm>(`api/v1/checkout/form`, "get"),

  updateContact: async (contact: CheckoutContact) =>
    await makeRequest<string>(`api/v1/checkout/contact`, "patch", contact),

  updateShipping: async (address: PostalAddress) =>
    await makeRequest<string>(`api/v1/checkout/shipping`, "patch", address),

  updateBilling: async (billing: CheckoutBilling) =>
    await makeRequest<string>(`api/v1/checkout/billing`, "patch", billing),

  confirmCheckout: async () =>
    await makeRequest(`api/v1/checkout/confirm`, "post"),
}
export default checkoutApi
