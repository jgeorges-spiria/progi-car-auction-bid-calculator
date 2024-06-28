import { expect, test, beforeEach, afterEach, vi, describe } from "vitest";
import { render, screen } from "@testing-library/vue";
import userEvent, { UserEvent } from "@testing-library/user-event";
import CarDetailsForm from "../../../../features/bid-calculator/components/car-details-form.vue";
import { VehicleType } from "../../../../models/vehicle/vehicle-type.enum";
import { TestId } from "../../../../test-id";

describe("CarDetailsForm", () => {
  let user: UserEvent;
  beforeEach(() => {
    vi.useFakeTimers();
    user = userEvent.setup({ advanceTimers: vi.advanceTimersByTime });
  });

  afterEach(() => {
    vi.useRealTimers();
  });

  test("should show vehicle price error when vehicle price is invalid", async () => {
    render(CarDetailsForm);
    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await user.type(vehiclePriceInput, "abcd");
    const vehiclePriceErrorMessage = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceErrorMessage,
    );
    expect(vehiclePriceErrorMessage.style.display).toBe("");
  });

  test("should emit 'calculateBid' with valid vehicle price and default vehicle type after debounce", async () => {
    const component = render(CarDetailsForm);

    const expectedVehiclePrice = "100";
    const expectedVehicleType = VehicleType.Common;

    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await user.type(vehiclePriceInput, expectedVehiclePrice);

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

    const vehiclePriceInput = screen.getByTestId(
      TestId.CarDetailsForm.VehiclePriceInput,
    );
    await user.type(vehiclePriceInput, expectedVehiclePrice);

    const vehicleTypeSelect = screen.getByTestId(
      TestId.CarDetailsForm.VehicleTypeSelect,
    );
    await user.selectOptions(vehicleTypeSelect, expectedVehicleType);

    vi.runAllTimers();
    const emitResult = component.emitted("calculateBid");
    expect(emitResult.length).toBe(1);
    expect(emitResult[0]).toStrictEqual([
      expectedVehiclePrice,
      expectedVehicleType,
    ]);
  });
});
