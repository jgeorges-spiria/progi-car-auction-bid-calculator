import {
  afterAll,
  afterEach,
  beforeAll,
  beforeEach,
  describe,
  expect,
  test,
  vi,
} from "vitest";
import { fireEvent, render, screen, within } from "@testing-library/vue";
import { ApiInterceptor } from "../resources/api-interceptor/api-interceptor";
import BidCalculatorFeature from "../../../features/bid-calculator/bid-calculator.feature.vue";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";
import { MOCK_SERVER_ERROR_VEHICLE_PRICE } from "../resources/mocks/mock.constants";
import { TestId } from "../../../test-id";

describe("BidCalculatorFeature", () => {
  beforeAll(() => {
    ApiInterceptor.listen();
  });

  beforeEach(() => {
    vi.useFakeTimers();
  });

  afterEach(() => {
    vi.useRealTimers();
  });

  afterAll(() => {
    ApiInterceptor.dispose();
  });

  test("it should default the bid calculation values and show the error banner when the API request fails", async () => {
    render(BidCalculatorFeature);
    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await fireEvent.update(
      vehiclePriceInput,
      `${MOCK_SERVER_ERROR_VEHICLE_PRICE}`,
    );
    await vi.runAllTimersAsync();
    const banner = screen.getByTestId(
      TestId.FailedBidCalculationErrorBanner.ErrorBanner,
    );
    expect(banner.style.display).toBe("");

    const expectedCost = "$0.00";
    const expectedVehicleType = VehicleType.Common;
    [
      [TestId.BidCalculationTable.DesktopTable.VehiclePrice, expectedCost],
      [TestId.BidCalculationTable.MobileTable.VehiclePrice, expectedCost],
      [
        TestId.BidCalculationTable.DesktopTable.VehicleType,
        expectedVehicleType,
      ],
      [TestId.BidCalculationTable.MobileTable.VehicleType, expectedVehicleType],
      [TestId.BidCalculationTable.DesktopTable.BasicFee, expectedCost],
      [TestId.BidCalculationTable.MobileTable.BasicFee, expectedCost],
      [TestId.BidCalculationTable.DesktopTable.SpecialFee, expectedCost],
      [TestId.BidCalculationTable.MobileTable.SpecialFee, expectedCost],
      [TestId.BidCalculationTable.DesktopTable.AssociationFee, expectedCost],
      [TestId.BidCalculationTable.MobileTable.AssociationFee, expectedCost],
      [TestId.BidCalculationTable.DesktopTable.StorageFee, expectedCost],
      [TestId.BidCalculationTable.MobileTable.StorageFee, expectedCost],
      [TestId.BidCalculationTable.DesktopTable.Total, expectedCost],
      [TestId.BidCalculationTable.MobileTable.Total, expectedCost],
    ].forEach(([testId, expectedText]) => {
      within(screen.getByTestId(testId)).getByText(expectedText);
    });
  });

  test("it should render the bid calculation values returned from the API and hide the error-banner", async () => {
    render(BidCalculatorFeature);
    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await fireEvent.update(vehiclePriceInput, "2800");
    await vi.runAllTimersAsync();

    const banner = screen.getByTestId(
      TestId.FailedBidCalculationErrorBanner.ErrorBanner,
    );
    expect(banner.style.display).toBe("none");

    const expectedVehiclePrice = "$2,800.00";
    const expectedVehicleType = VehicleType.Luxury;
    const expectedBasicFee = "$200.00";
    const expectedSpecialFee = "$112.00";
    const expectedAssociationFee = "$15.00";
    const expectedStorageFee = "$100.00";
    const expectedTotal = "$3,227.00";

    [
      [
        TestId.BidCalculationTable.DesktopTable.VehiclePrice,
        expectedVehiclePrice,
      ],
      [
        TestId.BidCalculationTable.MobileTable.VehiclePrice,
        expectedVehiclePrice,
      ],
      [
        TestId.BidCalculationTable.DesktopTable.VehicleType,
        expectedVehicleType,
      ],
      [TestId.BidCalculationTable.MobileTable.VehicleType, expectedVehicleType],
      [TestId.BidCalculationTable.DesktopTable.BasicFee, expectedBasicFee],
      [TestId.BidCalculationTable.MobileTable.BasicFee, expectedBasicFee],
      [TestId.BidCalculationTable.DesktopTable.SpecialFee, expectedSpecialFee],
      [TestId.BidCalculationTable.MobileTable.SpecialFee, expectedSpecialFee],
      [
        TestId.BidCalculationTable.DesktopTable.AssociationFee,
        expectedAssociationFee,
      ],
      [
        TestId.BidCalculationTable.MobileTable.AssociationFee,
        expectedAssociationFee,
      ],
      [TestId.BidCalculationTable.DesktopTable.StorageFee, expectedStorageFee],
      [TestId.BidCalculationTable.MobileTable.StorageFee, expectedStorageFee],
      [TestId.BidCalculationTable.DesktopTable.Total, expectedTotal],
      [TestId.BidCalculationTable.MobileTable.Total, expectedTotal],
    ].forEach(([testId, expectedText]) => {
      within(screen.getByTestId(testId)).getByText(expectedText);
    });
  });
});
