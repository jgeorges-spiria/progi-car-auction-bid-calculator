import { http, HttpResponse, PathParams } from "msw";
import { CarAuctionBidApiService } from "../../../../api/car-auction-bid-api/services/car-auction-bid-api.service";
import { BidCalculationRequestDto } from "../../../../api/car-auction-bid-api/dto/bid-calculation-request.dto";
import { MOCK_SERVER_ERROR_VEHICLE_PRICE } from "../mocks/mock.constants";

export const APIInterceptorHandlers = [
  http.post<PathParams, BidCalculationRequestDto>(
    CarAuctionBidApiService.paths.calculateBid,
    async ({ request }) => {
      const body = await request.json();
      if (body.vehiclePrice === MOCK_SERVER_ERROR_VEHICLE_PRICE) {
        return HttpResponse.json(
          { status: 500, error: "INTERNAL_SERVER_ERROR" },
          { status: 500 },
        );
      }
      return HttpResponse.json({
        vehiclePrice: 2800,
        vehicleType: "luxury",
        basicFee: 200,
        specialFee: 112,
        associationFee: 15,
        storageFee: 100,
        total: 3227,
      });
    },
  ),
];
