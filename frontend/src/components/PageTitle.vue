<script setup lang="ts">
const props = defineProps<{
  title: string
}>();
</script>

<template>
  <div>
    <h1 class="text-2xl text-textLight dark:text-textDark mb-8">{{ props.title }}</h1>
  </div>
</template>