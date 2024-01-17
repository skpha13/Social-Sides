<script setup lang="ts">
import type { IComment } from '@/models/Comment'
import { getTimeElapsed } from '@/utils/DateUtils'
import { ref } from 'vue'
import { store } from '@/Helpers/Authenticated'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const formattedDate = ref<string>("");
const userName = ref<string>("Unknown");
const showDelete = ref<boolean>(false);

const props = defineProps<{
  comments: IComment
}>();

const emits = defineEmits<{
  (e: 'comment-delete', payload: {
    commentId: string
  }): void
}>();

if (props.comments.userId == store.userId) {
  userName.value = "You";
  showDelete.value = true;
} else {
  userName.value = props.comments.userName;
}

formattedDate.value = getTimeElapsed(props.comments.lastModified);
setInterval(() => {
  formattedDate.value = getTimeElapsed(props.comments.lastModified);
},500);
</script>

<template>
  <div class="mt-2 mb-6">
    <div class="flex flex-row justify-between items-center mr-4">
      <div class="flex flex-row items-center">
        <h1 class="text-sm py-1 px-4 min-w-[80px] hover:backdrop-brightness-200">{{ userName }}</h1>
        <p class="text-sm text-textLight dark:text-textDark">{{ formattedDate }}</p>
      </div>
      <font-awesome-icon v-if="showDelete"
                         icon="fa-regular fa-trash-can"
                         class="text-sm hover:cursor-pointer text-red-600"
                         @click="emits('comment-delete',{commentId: props.comments.id})"
      />
    </div>
    <p class="text-sm px-4 text-textLight dark:text-textDark">{{ props.comments.text }}</p>
  </div>
</template>