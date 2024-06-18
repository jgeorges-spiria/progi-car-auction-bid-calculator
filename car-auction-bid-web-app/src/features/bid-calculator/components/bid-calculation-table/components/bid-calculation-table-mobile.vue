<script setup lang="ts">
import { PropType } from 'vue'
import { CurrencyFormatter } from '../../../../../shared/formatters/currency.formatter';
import { BidCalculation } from "../../../../../models/bid-calculation/bid-calculation.interface"

const props = defineProps({
    'bidCalculation': { type: Object as PropType<BidCalculation>, required: true }
});

</script>

<template>
    <table class="bidCalculationTable">
        <tbody>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Vehicle Price</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.vehiclePrice) }}</td>
            </tr>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Basic Fee</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.basicFee) }}</td>
            </tr>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Special Fee</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.specialFee) }}</td>
            </tr>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Association Fee</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.associationFee) }}</td>
            </tr>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Storage Fee</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.storageFee) }}</td>
            </tr>
            <tr class="bidCalculationTableRow">
                <td class="bidCalculationTableRowItem">Total</td>
                <td class="bidCalculationTableRowItem">{{ CurrencyFormatter.format(props.bidCalculation.total) }}</td>
            </tr>
        </tbody>
    </table>
</template>

<style scoped>
.bidCalculationTable {
 width: 100%;
}

.bidCalculationTableRow {
}
.bidCalculationTableRowItem {
    padding: 0.5em 1em;
    border: 1px solid #eeeeee
}
</style>