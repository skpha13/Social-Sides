<script setup lang="ts">
const props = defineProps<{
  id: string
  title: string
  color: string
}>();
</script>

<template>
  <button
    class="text-sm text-center
            border rounded-xl py-0.5 px-4 mx-4 min-w-[80px]
            hover:backdrop-brightness-200
    " :style="{color: props.color, borderColor: props.color}">{{ props.title }}</button>
</template>