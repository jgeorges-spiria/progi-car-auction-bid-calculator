export class CurrencyFormatter {
  private static formatter = new Intl.NumberFormat("en-CA", {
    style: "currency",
    currency: "CAD",
  });

  public static format(input: number | bigint): string {
    return this.formatter.format(input);
  }
}
