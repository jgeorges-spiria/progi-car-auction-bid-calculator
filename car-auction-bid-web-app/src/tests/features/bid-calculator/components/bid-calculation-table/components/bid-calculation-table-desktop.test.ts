import { test, describe, beforeEach } from "vitest";
import { render, screen, within } from "@testing-library/vue";
import BidCalculationTableDesktop from "../../../../../../features/bid-calculator/components/bid-calculation-table/components/bid-calculation-table-desktop.vue";
import { BidCalculation } from "../../../../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../../../../models/vehicle/vehicle-type.enum";
import { TestId } from "../../../../../../test-id";

describe("BidCalculationTableDesktop", () => {
  let bidCalculation: BidCalculation;

  beforeEach(() => {
    bidCalculation = {
      vehiclePrice: 1000,
      vehicleType: VehicleType.Common,
      basicFee: 10,
      specialFee: 20,
      associationFee: 30,
      storageFee: 100,
      total: 1160,
    };
  });

  test("should render the all of the properties of bid calculation with prices in a currency format", () => {
    render(BidCalculationTableDesktop, { props: { bidCalculation } });
    const vehiclePrice = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.VehiclePrice,
    );
    const vehicleType = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.VehicleType,
    );
    const basicFee = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.BasicFee,
    );
    const specialFee = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.SpecialFee,
    );
    const associationFee = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.AssociationFee,
    );
    const storageFee = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.StorageFee,
    );
    const total = screen.getByTestId(
      TestId.BidCalculationTable.DesktopTable.Total,
    );

    within(vehiclePrice).getByText("$1,000.00");
    within(vehicleType).getByText(VehicleType.Common);
    within(basicFee).getByText("$10.00");
    within(specialFee).getByText("$20.00");
    within(associationFee).getByText("$30.00");
    within(storageFee).getByText("$100.00");
    within(total).getByText("$1,160.00");
  });
});
