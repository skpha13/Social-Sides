<script setup lang="ts">
import type { IComment } from '@/models/Comment'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const props = defineProps<{
  postId: string,
  comments: IComment[]
}>();

const emits = defineEmits<{
  (e: 'close-popup'): void,
}>();

</script>

<template>
  <div class="fixed top-0 left-0 w-full h-full flex items-center justify-center">
      <div class="px-4 pt-2 w-96 h-4/5 md:w-128 rounded-lg
          bg-backgroundLight-mute dark:bg-backgroundDark-mute">
        <div class="flex justify-between border-b
                     border-borderLight-default dark:border-borderDark-default">
          <h1 class="text-textLight dark:text-textDark text-lg">
            Comments
          </h1>
          <font-awesome-icon icon="fa-solid fa-xmark"
                             @click="emits('close-popup')"
                             class="relative top-1 hover:cursor-pointer text-xl
                                    text-textLight dark:text-textDark" />
        </div>
      </div>
  </div>
</template>