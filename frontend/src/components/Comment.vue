<script setup lang="ts">
import type { IComment } from '@/models/Comment'
import { getTimeElapsed } from '@/utils/DateUtils'
import { ref } from 'vue'

const formattedDate = ref<string>("");

const props = defineProps<{
  comments: IComment[]
}>();

formattedDate.value = getTimeElapsed(props.comments.lastModified);
setInterval(() => {
  formattedDate.value = getTimeElapsed(props.comments.lastModified);
},500);
</script>

<template>
  <div class="mt-2 mb-6">
    <div class="flex flex-row items-center">
      <h1 class="text-sm py-1 px-4 min-w-[80px] hover:backdrop-brightness-200">{{ props.comments.userName }}</h1>
      <p class="text-sm text-textLight dark:text-textDark">{{ formattedDate }}</p>
    </div>
    <p class="text-sm px-4 text-textLight dark:text-textDark">{{ props.comments.text }}</p>
  </div>
</template>