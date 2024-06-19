export class Debouncer {
  private currentDebounce: NodeJS.Timeout | null = null;

  public debounce(callback: () => void, delayInMillis = 0): void {
    if (this.currentDebounce !== null) {
      clearTimeout(this.currentDebounce);
    }
    this.currentDebounce = setTimeout(() => {
      callback();
    }, delayInMillis);
  }

  public clear(): void {
    if (this.currentDebounce !== null) {
      clearTimeout(this.currentDebounce);
    }
  }
}
