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
import { render, screen, within } from "@testing-library/vue";
import userEvent, { UserEvent } from "@testing-library/user-event";
import { createApiInterceptor } from "../resources/api-interceptor/api-interceptor";
import BidCalculatorFeature from "../../../features/bid-calculator/bid-calculator.feature.vue";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";
import { TestId } from "../../../test-id";
import { HttpHandler, HttpResponse, http } from "msw";
import { CarAuctionBidApiService } from "../../../api/car-auction-bid-api/services/car-auction-bid-api.service";

describe("BidCalculatorFeature", () => {
  const apiInterceptor = createApiInterceptor();
  let user: UserEvent;
  beforeAll(() => {
    apiInterceptor.listen({ onUnhandledRequest: "error" });
  });

  beforeEach(() => {
    vi.useFakeTimers();
    user = userEvent.setup({ advanceTimers: vi.advanceTimersByTime });
  });

  afterEach(() => {
    vi.runOnlyPendingTimers();
    vi.useRealTimers();
    apiInterceptor.resetHandlers();
  });

  afterAll(() => {
    apiInterceptor.dispose();
  });

  function createApiInterceptorResponse(
    payload: object,
    statusCode: number = 200,
  ): HttpHandler {
    return http.post(CarAuctionBidApiService.paths.calculateBid, async () => {
      return HttpResponse.json(payload, { status: statusCode });
    });
  }

  test("it should default the bid calculation values and show the error banner when the API request fails", async () => {
    apiInterceptor.use(
      createApiInterceptorResponse({ error: "INTERNAL_SERVER_ERROR" }, 500),
    );
    render(BidCalculatorFeature);
    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await user.type(vehiclePriceInput, "500");
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
    apiInterceptor.use(
      createApiInterceptorResponse({
        vehiclePrice: 2800,
        vehicleType: "luxury",
        basicFee: 200,
        specialFee: 112,
        associationFee: 15,
        storageFee: 100,
        total: 3227,
      }),
    );
    render(BidCalculatorFeature);
    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await user.type(vehiclePriceInput, "2800");
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
