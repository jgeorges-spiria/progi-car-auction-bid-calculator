import { test, describe, beforeEach } from "vitest";
import { render, screen, within } from "@testing-library/vue";
import BidCalculationTableMobile from "../../../../../../features/bid-calculator/components/bid-calculation-table/components/bid-calculation-table-mobile.vue";
import { BidCalculation } from "../../../../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../../../../models/vehicle/vehicle-type.enum";

describe("BidCalculationTableMobile", () => {
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
    render(BidCalculationTableMobile, { props: { bidCalculation } });
    const vehiclePrice = screen.getByTestId("vehiclePriceMobile");
    const vehicleType = screen.getByTestId("vehicleTypeMobile");
    const basicFee = screen.getByTestId("basicFeeMobile");
    const specialFee = screen.getByTestId("specialFeeMobile");
    const associationFee = screen.getByTestId("associationFeeMobile");
    const storageFee = screen.getByTestId("storageFeeMobile");
    const total = screen.getByTestId("totalMobile");

    within(vehiclePrice).getByText("$1,000.00");
    within(vehicleType).getByText(VehicleType.Common);
    within(basicFee).getByText("$10.00");
    within(specialFee).getByText("$20.00");
    within(associationFee).getByText("$30.00");
    within(storageFee).getByText("$100.00");
    within(total).getByText("$1,160.00");
  });
});
