import { setupServer } from "msw/node";
import { APIInterceptorHandlers } from "./api-interceptor-handlers";

export const ApiInterceptor = setupServer(...APIInterceptorHandlers);
