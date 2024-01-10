<script setup lang="ts">
const props = defineProps<{
  title: string
  color: string
}>();
</script>

<template>
  <button
    class="text-sm text-center
            border rounded-xl py-0.5 px-4 mx-4 min-w-[80px]
    " :style="{color: props.color, borderColor: props.color}">{{ props.title }}</button>
</template>