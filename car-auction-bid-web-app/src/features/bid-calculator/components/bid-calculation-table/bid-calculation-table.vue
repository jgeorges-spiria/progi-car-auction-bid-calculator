<script setup lang="ts">
import { PropType, ref } from "vue";
import { BidCalculation } from "../../../../models/bid-calculation/bid-calculation.interface";
import BidCalculationTableDesktop from "./components/bid-calculation-table-desktop.vue";
import BidCalculationTableMobile from "./components/bid-calculation-table-mobile.vue";
import IsMobile from "../../../../shared/components/is-mobile.vue";
import { Color } from "../../../../shared/styles/color.enum";
import { TestId } from "../../../../test-id";

const props = defineProps({
  bidCalculation: { type: Object as PropType<BidCalculation>, required: true },
});

const isMobile = ref(false);

function handleIsMobile(isMobileFlag: boolean) {
  isMobile.value = isMobileFlag;
}
</script>

<template>
  <IsMobile @is-mobile="handleIsMobile"></IsMobile>
  <BidCalculationTableDesktop
    :data-testid="TestId.BidCalculationTable.Desktop"
    v-show="!isMobile"
    :bid-calculation="props.bidCalculation"
  ></BidCalculationTableDesktop>
  <BidCalculationTableMobile
    :data-testid="TestId.BidCalculationTable.Mobile"
    v-show="isMobile"
    :bid-calculation="props.bidCalculation"
  ></BidCalculationTableMobile>
</template>

<style scoped>
.bidCalculationTable {
  word-wrap: break-word;
}

.bidCalculationTableHeaderItem {
  padding: 0.5em 1em;
  border: 1px solid v-bind(Color.OffWhite);
}

.bidCalculationTableRowItem {
  padding: 0.5em 1em;
  border: 1px solid v-bind(Color.OffWhite);
}
</style>
