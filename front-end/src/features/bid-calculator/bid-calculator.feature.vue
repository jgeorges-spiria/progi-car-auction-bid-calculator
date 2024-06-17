<script setup lang="ts">
import { ref } from 'vue'
import CarDetailsForm from "./components/car-details-form/car-details-form.vue"

const count = ref(0)
</script>

<template>
  <h1>Car Auction <br> Bid Calculator</h1>

  <div class="card">
    <CarDetailsForm/>
  </div>

  
</template>

<style scoped>
.read-the-docs {
  color: #888;
}
</style>
