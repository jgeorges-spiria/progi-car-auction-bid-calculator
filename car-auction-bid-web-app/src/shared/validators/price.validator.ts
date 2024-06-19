export class PriceValidator {
  public static isValid(
    input: string,
    min: number = 0,
    max: number = Number.POSITIVE_INFINITY,
  ): boolean {
    const num = Number(input);
    if (Number.isNaN(num)) {
      return false;
    }
    return num >= min && num <= max;
  }
}
