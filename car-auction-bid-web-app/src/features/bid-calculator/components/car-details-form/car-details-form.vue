<script setup lang="ts">
import { Ref, ref } from 'vue'
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
        return;
    } else {
        showVehiclePriceError.value = !PriceValidator.isValid(input.target.value, MIN_VEHICLE_PRICE, MAX_VEHICLE_PRICE);    
    }

    calculateBid();
}

function calculateBid() {
    if (!showVehiclePriceError.value && vehiclePrice.value !== "") {
        debouncer.debounce(() => {
            emit('calculateBid', vehiclePrice.value, vehicleType.value);
        }, DEBOUNCE_DELAY_IN_MILLIS);
    }
}


</script>

<template>
    <form class="form" @submit.prevent>
        <div class="formInput">
            <label name="vehicle-price">Vehicle Price</label>
            <input
                class="vehiclePriceInput"
                v-model.trim="vehiclePrice" 
                @input="handleVehiclePriceChange" 
                name="vehicle-price" 
                :maxLength=MAX_VEHICLE_PRICE_LENGTH 
                type="text" 
                placeholder="1 - 999,999,999"
                :class="{ inputError: showVehiclePriceError }">
        </div>
        <div class="formInput">
            <label name="vehicle-type">Vehicle Type</label>
            <select class="vehicleTypeInput" v-model="vehicleType" @input="calculateBid">
                <option v-for="option in vehicleTypeOptions" :value="option.value">
                    {{ option.value }}
                </option>
            </select>
        </div>
    </form>
    <span v-show="showVehiclePriceError">Invalid Vehicle Price. Numbers only please.</span>
</template>

<style scoped>

.form {
    display: flex;
    align-items: center;
    justify-content: center;
    flex-wrap: wrap;
}

.formInput {
    display: flex;
    flex-direction: column;
    text-align: left;
    margin-right: 2em;
    margin-bottom: 3em;
}

.vehiclePriceInput {
    border-radius: 8px;
    border: 1px solid #e2e2e2;
    margin-top: 0.5em;
    padding: 0.6em 0.6em;
    font-size: 1em;
}
.vehicleTypeInput {
    border-radius: 8px;
    border: 1px solid #e2e2e2;
    margin-top: 0.5em;
    padding: 0.6em 2em;
    font-size: 1em;
}
.inputError {
    border-color: red;
}
</style>
