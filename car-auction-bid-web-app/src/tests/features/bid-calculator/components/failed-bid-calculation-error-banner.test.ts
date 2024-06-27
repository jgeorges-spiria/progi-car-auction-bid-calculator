import { describe, expect, test } from "vitest";
import { render, screen } from "@testing-library/vue";
import FailedBidCalculationErrorBanner from "../../../../features/bid-calculator/components/failed-bid-calculation-error-banner.vue";
import { TestId } from "../../../../test-id";

describe("FailedBidCalculationErrorBanner", () => {
  test("should show banner when showBanner is true", async () => {
    render(FailedBidCalculationErrorBanner, { props: { showBanner: true } });
    const banner = screen.getByTestId(
      TestId.FailedBidCalculationErrorBanner.ErrorBanner,
    );
    expect(banner.style.display).toBe("");
  });

  test("should hide banner when showBanner is false", async () => {
    render(FailedBidCalculationErrorBanner, { props: { showBanner: false } });
    const banner = screen.getByTestId(
      TestId.FailedBidCalculationErrorBanner.ErrorBanner,
    );
    expect(banner.style.display).toBe("none");
  });

  test("should emit 'hide' even when OK button is clicked inside banner", async () => {
    const component = render(FailedBidCalculationErrorBanner, {
      props: { showBanner: true },
    });

    const okButton = screen.getByText("OK");
    okButton.click();

    expect(component.emitted("hide").length).toBe(1);
  });
});
