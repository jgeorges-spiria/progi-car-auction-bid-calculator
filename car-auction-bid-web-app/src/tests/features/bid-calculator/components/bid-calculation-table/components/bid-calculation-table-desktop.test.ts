import { test, describe, beforeEach } from "vitest";
import { render, screen, within } from "@testing-library/vue";
import BidCalculationTableDesktop from "../../../../../../features/bid-calculator/components/bid-calculation-table/components/bid-calculation-table-desktop.vue";
import { BidCalculation } from "../../../../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../../../../models/vehicle/vehicle-type.enum";

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
    const vehiclePrice = screen.getByTestId("vehiclePriceDesktop");
    const vehicleType = screen.getByTestId("vehicleTypeDesktop");
    const basicFee = screen.getByTestId("basicFeeDesktop");
    const specialFee = screen.getByTestId("specialFeeDesktop");
    const associationFee = screen.getByTestId("associationFeeDesktop");
    const storageFee = screen.getByTestId("storageFeeDesktop");
    const total = screen.getByTestId("totalDesktop");

    within(vehiclePrice).getByText("$1,000.00");
    within(vehicleType).getByText(VehicleType.Common);
    within(basicFee).getByText("$10.00");
    within(specialFee).getByText("$20.00");
    within(associationFee).getByText("$30.00");
    within(storageFee).getByText("$100.00");
    within(total).getByText("$1,160.00");
  });
});
