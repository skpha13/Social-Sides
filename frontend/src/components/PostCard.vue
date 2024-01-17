<script setup lang="ts">
import type { ICategory } from '@/models/Category'
import type { IUser } from '@/models/User'
import { getTimeElapsed } from '@/utils/DateUtils'
import { ref } from 'vue'
import { store } from '@/Helpers/Authenticated'
import type { IComment } from '@/models/Comment'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const formattedDate = ref<string>("");
const userName = ref<string>("Unknown");
const showCategory = ref(false);
const heartType = ref<string>("fa-regular fa-heart");
// false represents regular, and true solid
// false = unlike, true = like
var isOfType: boolean = false;

const props = defineProps<{
  id: string,
  text: string,
  totalLikes: number,
  isLiked: boolean,
  user: IUser
  category?: ICategory
  comments: IComment[]
  date: string
}>();

const emit = defineEmits<{
  (e: 'like-action', payload: {
    option: boolean,
    postId: string
  }): void,

  (e: 'comment-popup', payload: {
    postId: string,
    comments: IComment[]
  }) : void

}>();

if (props.user.id == store.userId) {
  userName.value = "You";
} else {
  userName.value = props.user.userName;
}

if (props.category) {
  showCategory.value = true;
}

if (props.isLiked) {
  heartType.value = "fa-solid fa-heart";
  isOfType = true;
}

// setInterval starts after 0.5s, so to reduce the wait time
// i called the function immediately before
formattedDate.value = getTimeElapsed(props.date);
setInterval(() => {
  formattedDate.value = getTimeElapsed(props.date);
},500);

const handleLike = () => {
  heartType.value = isOfType ? "fa-regular fa-heart" : "fa-solid fa-heart"
  isOfType = !isOfType;
  emit('like-action', {option: isOfType, postId: props.id});
}
</script>

<template>
  <div class="w-96 sm:w-[512px] sm:mx-8 py-2 px-4 border rounded-lg border-borderLight-default dark:border-borderDark-default mb-4">
    <div class="flex flex-row justify-between mb-2">
      <button v-if="showCategory"
        class="text-sm border rounded-xl py-1 px-4 min-w-[80px] hover:backdrop-brightness-200"
        :style="{color: props.category.color, borderColor: props.category.color}">
        {{ props.category.title }}
      </button>
      <h1 v-else class="text-sm border rounded-xl py-1 px-4 min-w-[80px] hover:backdrop-brightness-200">Unknown</h1>
      <p class="text-sm text-textLight dark:text-textDark">{{ formattedDate }}</p>
    </div>

    <div class="mx-4">
      <h2 class="font-bold"> {{ userName }} </h2>
      <p class="text-textLight dark:text-textDark"> {{ props.text }} </p>
    </div>

    <div class="flex flex-row items-center
          border-t border-borderLight-default dark:border-borderDark-default mt-2">
      <font-awesome-icon @click="handleLike" :icon="heartType" class="mt-2 hover:cursor-pointer mr-2"/>
      <p class="flex-grow text-sm text-textLight dark:text-textDark mr-8 relative top-[0.15rem]">{{ totalLikes }}</p>
      <font-awesome-icon @click="emit('comment-popup',{postId: id, comments: comments})" icon="fa-regular fa-message" class="mt-2 hover:cursor-pointer"/>
    </div>
  </div>
</template>