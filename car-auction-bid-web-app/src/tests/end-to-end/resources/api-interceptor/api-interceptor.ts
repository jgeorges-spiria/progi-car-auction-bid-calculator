import { setupServer } from "msw/node";
import { DefaultApiInterceptorHandlers } from "./api-interceptor-handlers";

export const createApiInterceptor = () =>
  setupServer(...DefaultApiInterceptorHandlers);
