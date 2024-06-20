import { expect, test, beforeEach, afterEach, vi, describe } from "vitest";
import { fireEvent, render, screen } from "@testing-library/vue";
import CarDetailsForm from "../../../../features/bid-calculator/components/car-details-form.vue";
import { VehicleType } from "../../../../models/vehicle/vehicle-type.enum";

describe("CarDetailsForm", () => {
  beforeEach(() => {
    // tell vitest we use mocked time
    vi.useFakeTimers();
  });

  afterEach(() => {
    // restoring date after each test run
    vi.useRealTimers();
  });

  test("should show vehicle price error when vehicle price is invalid", async () => {
    render(CarDetailsForm);
    const vehiclePriceInput = screen.getByTestId("vehiclePriceInput");
    await fireEvent.update(vehiclePriceInput, "abcd");
    const vehiclePriceErrorMessage = screen.getByTestId(
      "vehiclePriceErrorMessage",
    );
    expect(vehiclePriceErrorMessage.style.display).toBe("");
  });

  test("should emit 'calculateBid' with valid vehicle price and default vehicle type after debounce", async () => {
    const component = render(CarDetailsForm);

    const expectedVehiclePrice = "100";
    const expectedVehicleType = VehicleType.Common;

    const vehiclePriceInput = screen.getByTestId("vehiclePriceInput");
    await fireEvent.update(vehiclePriceInput, expectedVehiclePrice);

    vi.runAllTimers();
    const emitResult = component.emitted("calculateBid");
    expect(emitResult.length).toBe(1);
    expect(emitResult[0]).toStrictEqual([
      expectedVehiclePrice,
      expectedVehicleType,
    ]);
  });

  test("should emit 'calculateBid' with valid vehicle price and selected vehicle type after debounce", async () => {
    const component = render(CarDetailsForm);

    const expectedVehiclePrice = "100";
    const expectedVehicleType = VehicleType.Luxury;

    const vehiclePriceInput = screen.getByTestId("vehiclePriceInput");
    await fireEvent.update(vehiclePriceInput, expectedVehiclePrice);

    const vehicleTypeSelect = screen.getByTestId("vehicleTypeSelect");
    await fireEvent.update(vehicleTypeSelect, expectedVehicleType);

    vi.runAllTimers();
    const emitResult = component.emitted("calculateBid");
    expect(emitResult.length).toBe(1);
    expect(emitResult[0]).toStrictEqual([
      expectedVehiclePrice,
      expectedVehicleType,
    ]);
  });
});
