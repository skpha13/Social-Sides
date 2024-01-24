<script setup lang="ts">
const props = defineProps<{
  id: string
  title: string
  color: string
}>();

const emit = defineEmits<{
  (e: 'filter-by-category', id:string): void
}>()
</script>

<template>
  <button
    @click="emit('filter-by-category', props.id)"
    class="text-sm text-center
            border rounded-xl py-0.5 px-4 mx-4 min-w-[80px]
            hover:backdrop-brightness-200
    " :style="{color: props.color, borderColor: props.color}">{{ props.title }}</button>
</template>