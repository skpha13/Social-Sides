<script setup lang="ts">
import type { IComment } from '@/models/Comment'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import Comment from '@/components/Comment.vue'

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
        <div class="flex justify-between border-b pb-1
                     border-borderLight-default dark:border-borderDark-default">
          <h1 class="text-textLight dark:text-textDark text-base">
            Comments
          </h1>
          <font-awesome-icon icon="fa-solid fa-xmark"
                             @click="emits('close-popup')"
                             class="relative top-1 hover:cursor-pointer text-lg
                                    text-textLight dark:text-textDark" />
        </div>

        <Comment v-for="(item,index) in props.comments"
                 :key="index"
                 :comments="item"
        />
      </div>
  </div>
</template>