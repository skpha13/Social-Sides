<script setup lang="ts">
const props = defineProps<{
  title: string
  color: string
}>();
</script>

<template>
  <h1
    class="text-sm text-center
            border rounded-xl p-0.5 w-20 mx-4 min-w-[80px]
    " :style="{color: props.color, borderColor: props.color}">{{ props.title }}</h1>
</template>