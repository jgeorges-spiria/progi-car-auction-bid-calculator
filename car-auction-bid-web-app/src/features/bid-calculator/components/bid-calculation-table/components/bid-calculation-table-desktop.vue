<script setup lang="ts">
import { PropType } from "vue";
import { CurrencyFormatter } from "../../../../../shared/formatters/currency.formatter";
import { BidCalculation } from "../../../../../models/bid-calculation/bid-calculation.interface";

const props = defineProps({
  bidCalculation: { type: Object as PropType<BidCalculation>, required: true },
});
</script>

<template>
  <table>
    <thead>
      <th class="bidCalculationTableHeaderItem">Vehicle Price</th>
      <th class="bidCalculationTableHeaderItem">Vehicle Type</th>
      <th class="bidCalculationTableHeaderItem">Basic Fee</th>
      <th class="bidCalculationTableHeaderItem">Special Fee</th>
      <th class="bidCalculationTableHeaderItem">Association Fee</th>
      <th class="bidCalculationTableHeaderItem">Storage Fee</th>
      <th class="bidCalculationTableHeaderItem">Total</th>
    </thead>
    <tbody>
      <tr>
        <td
          data-testid="vehiclePriceDesktop"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.vehiclePrice) }}
        </td>
        <td data-testid="vehicleTypeDesktop" class="bidCalculationTableRowItem">
          {{ props.bidCalculation.vehicleType }}
        </td>
        <td data-testid="basicFeeDesktop" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.basicFee) }}
        </td>
        <td data-testid="specialFeeDesktop" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.specialFee) }}
        </td>
        <td
          data-testid="associationFeeDesktop"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.associationFee) }}
        </td>
        <td data-testid="storageFeeDesktop" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.storageFee) }}
        </td>
        <td data-testid="totalDesktop" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.total) }}
        </td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped>
.bidCalculationTableHeaderItem {
  padding: 0.5em 1em;
  border: 1px solid #eeeeee;
}
.bidCalculationTableRowItem {
  padding: 0.5em 1em;
  border: 1px solid #eeeeee;
}
</style>
