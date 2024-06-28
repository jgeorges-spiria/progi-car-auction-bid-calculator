import { http, HttpResponse } from "msw";

export const DefaultApiInterceptorHandlers = [
  http.get("*", () => NotMockedResponse),
  http.post("*", () => NotMockedResponse),
  http.put("*", () => NotMockedResponse),
  http.delete("*", () => NotMockedResponse),
];

const NotMockedResponse = HttpResponse.json(
  { errorMessage: "Not mocked" },
  { status: 501 },
);
