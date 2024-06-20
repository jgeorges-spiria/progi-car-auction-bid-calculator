<script setup lang="ts">
import { PropType } from "vue";
import { CurrencyFormatter } from "../../../../../shared/formatters/currency.formatter";
import { BidCalculation } from "../../../../../models/bid-calculation/bid-calculation.interface";

const props = defineProps({
  bidCalculation: { type: Object as PropType<BidCalculation>, required: true },
});
</script>

<template>
  <table class="bidCalculationTable">
    <tbody>
      <tr>
        <td class="bidCalculationTableRowItem">Vehicle Price</td>
        <td data-testid="vehiclePrice" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.vehiclePrice) }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Vehicle Type</td>
        <td data-testid="vehicleType" class="bidCalculationTableRowItem">
          {{ props.bidCalculation.vehicleType }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Basic Fee</td>
        <td data-testid="basicFee" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.basicFee) }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Special Fee</td>
        <td data-testid="specialFee" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.specialFee) }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Association Fee</td>
        <td data-testid="associationFee" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.associationFee) }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Storage Fee</td>
        <td data-testid="storageFee" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.storageFee) }}
        </td>
      </tr>
      <tr>
        <td class="bidCalculationTableRowItem">Total</td>
        <td data-testid="total" class="bidCalculationTableRowItem">
          {{ CurrencyFormatter.format(props.bidCalculation.total) }}
        </td>
      </tr>
    </tbody>
  </table>
</template>

<style scoped>
.bidCalculationTable {
  width: 100%;
}

.bidCalculationTableRowItem {
  padding: 0.5em 1em;
  border: 1px solid #eeeeee;
}
</style>
