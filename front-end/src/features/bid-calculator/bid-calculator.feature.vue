<script setup lang="ts">
import { ref } from 'vue'
import CarDetailsForm from "./components/car-details-form/car-details-form.vue";
import BidCalculationTable from "./components/bid-calculation-table/bid-calculation-table.vue";
import { BidCalculationFactory } from "../../models/bid-calculation/bid-calculation.factory"

const count = ref(0);

const bidCalculation = ref(BidCalculationFactory.createDefault());

function fetchBidCalculation(vehiclePrice: string, vehicleType: VehicleType) {
    bidCalculation.value.vehiclePrice = Number(vehiclePrice);
    bidCalculation.value.vehicleType = vehicleType;

}

</script>

<template>
  <h1>Car Auction <br> Bid Calculator</h1>

  <div class="card">
    <CarDetailsForm @calculateBid="fetchBidCalculation"/>
  </div>
  <div class="card">
    <BidCalculationTable :bidCalculation="bidCalculation"/>
  </div>

  
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
