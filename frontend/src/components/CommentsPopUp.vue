<script setup lang="ts">
import type { IComment } from '@/models/Comment'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import Comment from '@/components/Comment.vue'
import { ref } from 'vue'

const text = ref<string>("");

const props = defineProps<{
  postId: string,
  comments: IComment[]
}>();

const emits = defineEmits<{
  (e: 'close-popup'): void,
  (e: 'comment-submit', payload: {
    postId: string,
    text: string
  }): void
}>();

const submitComment = () => {
  if (text.value.length === 0) return;

  emits('comment-submit', {
    postId: props.postId,
    text: text.value
  });

  text.value = "";
}

</script>

<template>
  <div class="fixed top-0 left-0 w-full h-full flex items-center justify-center">
      <div class="px-4 pt-2 w-96 h-4/5 md:w-128 rounded-lg
          bg-backgroundLight-mute dark:bg-backgroundDark-mute
          flex flex-col">
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

        <div class="overflow-x-scroll">
          <Comment v-for="(item,index) in props.comments"
                   :key="index"
                   :comments="item"
          />
        </div>

<!--    FORM AND SUBMIT BUTTON TO ADD COMMENT   -->
        <div class="grow w-full px-4 py-4 flex flex-col-reverse">
          <div class="flex flex-row justify-between items-center">
            <input id="comment"
              type="text"
              class="w-full outline-none bg-backgroundLight-soft dark:bg-backgroundDark-mute
                     focus:border-borderLight-hover dark:focus:border-borderDark-hover
                     border-2 border-borderLight-default dark:border-borderDark-default
                     rounded px-2 py-1 mr-2 text-sm"
              placeholder="Add a comment..."
              v-model="text"
            />
            <font-awesome-icon icon="fa-solid fa-share fa-xl"
                               @click="submitComment"
                               class="text-xl hover:cursor-pointer" />
          </div>
        </div>
      </div>
  </div>
</template>