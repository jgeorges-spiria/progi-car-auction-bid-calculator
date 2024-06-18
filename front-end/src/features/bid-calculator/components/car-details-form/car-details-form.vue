<script setup lang="ts">
import { Ref, ref, defineEmits } from 'vue'
import { VueInputEvent } from "../../../../shared/types/vue-input-event.interface"
import { PriceValidator } from '../../../../shared/validators/price.validator'
import { Debouncer } from '../../../../shared/utils/debouncer.util'
import { VehicleType } from "../../../../models/vehicle/vehicle-type.enum"
import { DEBOUNCE_DELAY_IN_MILLIS, MAX_VEHICLE_PRICE, MIN_VEHICLE_PRICE, MAX_VEHICLE_PRICE_LENGTH } from './types/car-details-form.constants';

const emit = defineEmits<{
    (e: 'calculateBid', vehiclePrice: string, vehicleType: VehicleType): void
}>();



const debouncer = new Debouncer();
const vehiclePrice: Ref<string> = ref("");
const vehicleType: Ref<VehicleType> = ref(VehicleType.Common);
const vehicleTypeOptions = ref([
  { value: VehicleType.Common },
  { value: VehicleType.Luxury },
])

const showVehiclePriceError: Ref<boolean> = ref(false);

function handleVehiclePriceChange(input: VueInputEvent): void {
    if (input.target.value === "") {
        showVehiclePriceError.value = false;
    } else {
        showVehiclePriceError.value = !PriceValidator.isValid(input.target.value, MIN_VEHICLE_PRICE, MAX_VEHICLE_PRICE);    
    }

    calculateBid();
}

function calculateBid() {
    if (!showVehiclePriceError.value) {
        console.log("DEBOUNCE STARTED");
        debouncer.debounce(() => {
            emit('calculateBid', vehiclePrice.value, vehicleType.value);
            console.log("DEBOUNCE DONE");
        }, DEBOUNCE_DELAY_IN_MILLIS);
    }
}


</script>

<template>
    <form @submit.prevent>
        <label name="vehicle-price">Vehicle Price</label>
        <input 
            v-model.trim="vehiclePrice" 
            @input="handleVehiclePriceChange" 
            name="vehicle-price" 
            :maxLength=MAX_VEHICLE_PRICE_LENGTH 
            type="text" 
            placeholder="1 - 999,999,999"
            :class="{ inputError: showVehiclePriceError }">
        <p v-show="showVehiclePriceError">Invalid Vehicle Price</p>
        <br/>
        <label name="vehicle-type">Vehicle Type</label>
        <select v-model="vehicleType" @input="calculateBid">
            <option v-for="option in vehicleTypeOptions" :value="option.value">
                {{ option.value }}
            </option>
        </select>
    </form>
</template>

<style scoped>
.inputError {
    border-color: red;
}
</style>
