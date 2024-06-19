import { PriceValidator } from "../../../shared/validators/price.validator";

describe("PriceValidator", () => {
  it("should return true if price is 60, min is 1 and max is 101", () => {
    expect(PriceValidator.isValid("60", 1, 101)).toBe(true);
  });
  it("should return true if price is 1, min is 1 and max is 101", () => {
    expect(PriceValidator.isValid("1", 1, 101)).toBe(true);
  });
  it("should return true if price is 101, min is 1 and max is 101", () => {
    expect(PriceValidator.isValid("101", 1, 101)).toBe(true);
  });
  it("should return false if price is 0, min is 1 and max is 101", () => {
    expect(PriceValidator.isValid("0", 1, 101)).toBe(false);
  });
  it("should return false if price is negative and min and max are defaulted", () => {
    expect(PriceValidator.isValid("-1")).toBe(false);
  });
  it("should return true if price is negative and min is more negative and max is defaulted", () => {
    expect(PriceValidator.isValid("-1", -2)).toBe(true);
  });
});
