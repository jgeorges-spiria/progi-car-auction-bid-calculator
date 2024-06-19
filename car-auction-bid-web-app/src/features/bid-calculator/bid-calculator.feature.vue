<script setup lang="ts">
import { ref } from 'vue'
import CarDetailsForm from "./components/car-details-form/car-details-form.vue";
import BidCalculationTable from "./components/bid-calculation-table/bid-calculation-table.vue";
import FailedBidCalculationErrorBanner from "./components/failed-bid-calculation-error-banner/failed-bid-calculation-error-banner.vue";
import { BidCalculationFactory } from "../../models/bid-calculation/bid-calculation.factory"
import { VehicleType } from '../../models/vehicle/vehicle-type.enum';
import { CarAuctionBidApiService } from "../../api/car-auction-bid-api/services/car-auction-bid-api.service"

const bidCalculation = ref(BidCalculationFactory.createDefault());
const showFailedBidCalculationError = ref(false);

async function fetchBidCalculation(vehiclePrice: string, vehicleType: VehicleType) {
    showFailedBidCalculationError.value = false;
    if (vehiclePrice.length === 0) {
      bidCalculation.value = BidCalculationFactory.createDefault();
      return;
    }


    const newBid = await CarAuctionBidApiService.calculateBid(vehiclePrice, vehicleType);
    if (newBid) {
      bidCalculation.value = newBid;
    } else {
      showFailedBidCalculationError.value = true;
      bidCalculation.value = BidCalculationFactory.createDefault();
    }
}

function hideFailedBidCalculatorErrorMessage() {
  showFailedBidCalculationError.value = false;
}

</script>

<template>
  <h1>Car Auction <br> Bid Calculator</h1>

  <div class="card">
    <CarDetailsForm @calculateBid="fetchBidCalculation"/>
  </div>
  <FailedBidCalculationErrorBanner :show-banner="showFailedBidCalculationError" @hide="hideFailedBidCalculatorErrorMessage"/>
  <div class="card">
    <BidCalculationTable :bidCalculation="bidCalculation"/>
  </div>  
</template>

<style scoped>

</style>
