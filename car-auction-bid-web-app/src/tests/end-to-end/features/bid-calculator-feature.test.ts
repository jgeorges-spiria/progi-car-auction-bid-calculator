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
    const vehiclePriceInput = screen.getByTestId("vehiclePriceInput");
    await fireEvent.update(
      vehiclePriceInput,
      `${MOCK_SERVER_ERROR_VEHICLE_PRICE}`,
    );
    await vi.runAllTimersAsync();
    const banner = screen.getByTestId("errorBanner");
    expect(banner.style.display).toBe("");

    const expectedCost = "$0.00";
    const expectedVehicleType = VehicleType.Common;
    [
      ["vehiclePriceDesktop", expectedCost],
      ["vehiclePriceMobile", expectedCost],
      ["vehicleTypeDesktop", expectedVehicleType],
      ["vehicleTypeMobile", expectedVehicleType],
      ["basicFeeDesktop", expectedCost],
      ["basicFeeMobile", expectedCost],
      ["specialFeeDesktop", expectedCost],
      ["specialFeeMobile", expectedCost],
      ["associationFeeDesktop", expectedCost],
      ["associationFeeMobile", expectedCost],
      ["storageFeeDesktop", expectedCost],
      ["storageFeeMobile", expectedCost],
      ["totalDesktop", expectedCost],
      ["totalMobile", expectedCost],
    ].forEach(([testId, expectedText]) => {
      within(screen.getByTestId(testId)).getByText(expectedText);
    });
  });

  test("it should render the bid calculation values returned from the API and hide the error-banner", async () => {
    render(BidCalculatorFeature);
    const vehiclePriceInput = screen.getByTestId("vehiclePriceInput");
    await fireEvent.update(vehiclePriceInput, "2800");
    await vi.runAllTimersAsync();

    const banner = screen.getByTestId("errorBanner");
    expect(banner.style.display).toBe("none");

    const expectedVehiclePrice = "$2,800.00";
    const expectedVehicleType = VehicleType.Luxury;
    const expectedBasicFee = "$200.00";
    const expectedSpecialFee = "$112.00";
    const expectedAssociationFee = "$15.00";
    const expectedStorageFee = "$100.00";
    const expectedTotal = "$3,227.00";

    [
      ["vehiclePriceDesktop", expectedVehiclePrice],
      ["vehiclePriceMobile", expectedVehiclePrice],
      ["vehicleTypeDesktop", expectedVehicleType],
      ["vehicleTypeMobile", expectedVehicleType],
      ["basicFeeDesktop", expectedBasicFee],
      ["basicFeeMobile", expectedBasicFee],
      ["specialFeeDesktop", expectedSpecialFee],
      ["specialFeeMobile", expectedSpecialFee],
      ["associationFeeDesktop", expectedAssociationFee],
      ["associationFeeMobile", expectedAssociationFee],
      ["storageFeeDesktop", expectedStorageFee],
      ["storageFeeMobile", expectedStorageFee],
      ["totalDesktop", expectedTotal],
      ["totalMobile", expectedTotal],
    ].forEach(([testId, expectedText]) => {
      within(screen.getByTestId(testId)).getByText(expectedText);
    });
  });
});
