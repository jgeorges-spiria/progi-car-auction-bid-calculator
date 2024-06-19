import { BidCalculation } from "../../../models/bid-calculation/bid-calculation.interface";

export class CarAuctionBidApiDtoMapper {
  public static mapDtoToBidCalculation(data: any): BidCalculation | null {
    if (data) {
      return {
        vehiclePrice: data.vehiclePrice,
        vehicleType: data.vehicleType,
        basicFee: data.basicFee,
        specialFee: data.specialFee,
        associationFee: data.associationFee,
        storageFee: data.storageFee,
        total: data.total,
      };
    }
    return null;
  }
}
