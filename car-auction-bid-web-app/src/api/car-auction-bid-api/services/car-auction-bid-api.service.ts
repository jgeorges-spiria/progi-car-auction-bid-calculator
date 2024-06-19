import { BidCalculation } from "../../../models/bid-calculation/bid-calculation.interface";
import { VehicleType } from "../../../models/vehicle/vehicle-type.enum";
import { HttpService } from "../../http.service";
import { BidCalculationResponseDto } from "../dto/bid-calculation-response.dto";
import { CarAuctionBidApiDtoMapper } from "../dto/car-auction-bid-api-dto-mapper";

export class CarAuctionBidApiService {
  private static baseUrl = import.meta.env.VITE_CAR_AUCTION_BID_API_BASE_URL;

  public static async calculateBid(
    vehiclePrice: string,
    vehicleType: VehicleType,
  ): Promise<BidCalculation | null> {
    try {
      const url = `${this.baseUrl}/bid/calculate`;
      const result = await HttpService.post(url, {
        vehiclePrice: Number(vehiclePrice),
        vehicleType,
      });
      const response = await result.json();
      if (result.ok) {
        return CarAuctionBidApiDtoMapper.mapToBidCalculation(
          response as BidCalculationResponseDto,
        );
      }
      return null;
    } catch (err) {
      return null;
    }
  }
}
