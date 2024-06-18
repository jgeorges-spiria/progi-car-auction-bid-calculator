<script setup lang="ts">
import { PropType, Ref, ref } from 'vue'
import { CurrencyFormatter } from '../../../../shared/formatters/currency.formatter';
import { BidCalculation } from "../../../../models/bid-calculation/bid-calculation.interface"

const props = defineProps({
    'bidCalculation': { type: Object as PropType<BidCalculation>, required: true }
});

</script>

<template>
    <table>
        <thead>
            <th>Vehicle Price</th>
            <th>Vehicle Type</th>
            <th>Basic Fee</th>
            <th>Special Fee</th>
            <th>Association Fee</th>
            <th>Storage Fee</th>
            <th>Total</th>
        </thead>
        <tbody>
            <tr>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.vehiclePrice) }}</td>
                <td>{{ props.bidCalculation.vehicleType }}</td>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.basicFee) }}</td>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.specialFee) }}</td>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.associationFee) }}</td>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.storageFee) }}</td>
                <td>{{ CurrencyFormatter.format(props.bidCalculation.total) }}</td>
            </tr>
        </tbody>
    </table>
</template>

<style scoped>

</style>