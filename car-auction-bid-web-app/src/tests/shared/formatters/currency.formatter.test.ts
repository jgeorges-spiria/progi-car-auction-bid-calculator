import { CurrencyFormatter } from "../../../shared/formatters/currency.formatter";

describe("CurrencyFormatter", () => {
  it("should return $500.01 for input 500.01", () => {
    expect(CurrencyFormatter.format(500.01)).toBe("$500.01");
  });

  it("should return $500.01 for input 500.014", () => {
    expect(CurrencyFormatter.format(500.014)).toBe("$500.01");
  });

  it("should return $500.02 for input 500.015", () => {
    expect(CurrencyFormatter.format(500.015)).toBe("$500.02");
  });
});
