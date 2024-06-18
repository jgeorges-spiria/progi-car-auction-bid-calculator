<script setup lang="ts">
import { onMounted, onUnmounted } from 'vue'
const emit = defineEmits<{
    (e: 'isMobile', flag: boolean): void
}>();

onMounted(() => {
    window.addEventListener("resize", handleWindowResize);
    handleWindowResize();
})

onUnmounted(() => {
    window.removeEventListener("resize", handleWindowResize);
    handleWindowResize();
})

function handleWindowResize() {
    if (window.innerWidth <= 768) {
        emit("isMobile", true);
    } else {
        emit("isMobile", false);
    }

}

</script>

<template>
</template>

<style scoped>
</style>