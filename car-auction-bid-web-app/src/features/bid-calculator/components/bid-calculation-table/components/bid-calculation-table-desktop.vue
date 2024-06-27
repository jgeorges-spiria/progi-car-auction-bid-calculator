<script setup lang="ts">
import { PropType } from "vue";
import { CurrencyFormatter } from "../../../../../shared/formatters/currency.formatter";
import { BidCalculation } from "../../../../../models/bid-calculation/bid-calculation.interface";
import { TestId } from "../../../../../test-id";

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
          :data-testid="TestId.BidCalculationTable.DesktopTable.VehiclePrice"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.vehiclePrice) }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.VehicleType"
          class="bidCalculationTableRowItem"
        >
          {{ props.bidCalculation.vehicleType }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.BasicFee"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.basicFee) }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.SpecialFee"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.specialFee) }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.AssociationFee"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.associationFee) }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.StorageFee"
          class="bidCalculationTableRowItem"
        >
          {{ CurrencyFormatter.format(props.bidCalculation.storageFee) }}
        </td>
        <td
          :data-testid="TestId.BidCalculationTable.DesktopTable.Total"
          class="bidCalculationTableRowItem"
        >
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
