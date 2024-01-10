<script setup lang="ts">
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const props = defineProps<{
  id: string
  title: string
  color: string
}>();
</script>

<template>
  <div class="flex flex-row justify-between hover:cursor-pointer
              text-xl mb-6 border-b">
    <h1>{{ props.title }}</h1>
    <div class="flex items-center w-24 justify-between border rounded-lg px-4 mb-2 hover:backdrop-brightness-200"
          :style="{color: props.color, borderColor: props.color}">
      <p class="text-base">Join</p>
      <FontAwesomeIcon icon="fa-solid fa-plus" size="sm" class="relative top-[0.04rem]"/>
    </div>
  </div>
</template>