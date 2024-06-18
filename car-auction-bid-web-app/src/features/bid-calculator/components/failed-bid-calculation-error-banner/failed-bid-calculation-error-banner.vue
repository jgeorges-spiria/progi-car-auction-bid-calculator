<script setup lang="ts">

const props = defineProps({
    'showBanner': { type: Boolean, required: true }
});

const emit = defineEmits<{
    (e: 'hide'): void
}>();

function hideBanner() {
  emit("hide");
}

</script>

<template>
  <p class="banner" v-show="props.showBanner">
    Failed to Calculate Bid. Please try again later.
    <br>
    <button class="errorButton" @click="hideBanner">OK</button>
  </p>
</template>

<style scoped>
.banner {
    background-color: #ff9595;
    color: #720000;
    border-radius: 8px;
    padding: 1em 1.2em;
    font-weight: 500;
}

.errorButton {
    margin-top: 0.75em;
    border-radius: 8px;
    border: 1px solid transparent;
    padding: 0.6em 2em;
    font-size: 0.8em;
    font-weight: 500;
    color: #ffffff;
    font-family: inherit;
    background-color: #986161;
    cursor: pointer;
    transition: border-color 0.25s;
}
.errorButton:hover {
  border-color: #720000;
  border-width: 1px;
}
.errorButton:focus,
.errorButton:focus-visible {
  outline: 4px auto -webkit-focus-ring-color;
}
</style>
