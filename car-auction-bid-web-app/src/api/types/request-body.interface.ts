

export type RequestBody = Record<string, RequestBodyFieldType>;
type RequestBodyFieldType = string | number | boolean | null | Record<string, string | number | boolean | null>