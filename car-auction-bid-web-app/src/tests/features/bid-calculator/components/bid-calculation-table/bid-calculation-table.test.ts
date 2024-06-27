import { expect, test, describe, beforeEach } from "vitest";
import { fireEvent, render, screen } from "@testing-library/vue";
import BidCalculationTable from "../../../../../features/bid-calculator/components/bid-calculation-table/bid-calculation-table.vue";
import { BidCalculation } from "../../../../../models/bid-calculation/bid-calculation.interface";
import { BidCalculationFactory } from "../../../../../models/bid-calculation/bid-calculation.factory";
import { TestId } from "../../../../../test-id";

describe("BidCalculationTable", () => {
  let bidCalculation: BidCalculation;

  beforeEach(() => {
    bidCalculation = BidCalculationFactory.createDefault();
  });

  test("should render the desktop version of the bid calculation table if the window size is not mobile", () => {
    render(BidCalculationTable, { props: { bidCalculation } });
    const desktopTable = screen.getByTestId(TestId.BidCalculationTable.Desktop);
    const mobileTable = screen.getByTestId(TestId.BidCalculationTable.Mobile);
    expect(desktopTable.style.display).toBe("");
    expect(mobileTable.style.display).toBe("none");
  });

  test("should render the mobile version of the bid calculation table if the window size is not mobile", async () => {
    render(BidCalculationTable, { props: { bidCalculation } });
    window.innerWidth = 100;
    await fireEvent(window, new Event("resize"));
    const desktopTable = screen.getByTestId(TestId.BidCalculationTable.Desktop);
    const mobileTable = screen.getByTestId(TestId.BidCalculationTable.Mobile);
    expect(desktopTable.style.display).toBe("none");
    expect(mobileTable.style.display).toBe("");
  });
});
