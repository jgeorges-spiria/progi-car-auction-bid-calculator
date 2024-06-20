import { describe, expect, test } from "vitest";
import { CurrencyFormatter } from "../../../shared/formatters/currency.formatter";

describe("CurrencyFormatter", () => {
  test("should return $500.01 for input 500.01", () => {
    expect(CurrencyFormatter.format(500.01)).toBe("$500.01");
  });

  test("should return $500.01 for input 500.014", () => {
    expect(CurrencyFormatter.format(500.014)).toBe("$500.01");
  });

  test("should return $500.02 for input 500.015", () => {
    expect(CurrencyFormatter.format(500.015)).toBe("$500.02");
  });
});
