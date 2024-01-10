<script setup lang="ts">
import type { ICategory } from '@/models/Category'
import type { IUser } from '@/models/User'
import { getTimeElapsed } from '@/utils/DateUtils'
import { ref } from 'vue'
import { store } from '@/Helpers/Authenticated'

const formattedDate = ref<string>("");
const userName = ref<string>("Unknown");

const props = defineProps<{
  text: string
  user: IUser
  category: ICategory
  date: string
}>();

if (props.user.id == store.userId) {
  userName.value = "You";
} else {
  userName.value = props.user.userName;
}

// setInterval starts after 0.5s, so to reduce the wait time
// i called the function immediately before
formattedDate.value = getTimeElapsed(props.date);
setInterval(() => {
  formattedDate.value = getTimeElapsed(props.date);
},500);
</script>

<template>
  <div class="w-96 sm:w-[512px] sm:mx-8 py-2 px-4 border rounded-lg border-borderLight-default dark:border-borderDark-default">
    <div class="flex flex-row justify-between mb-2">
      <button
        class="text-sm border rounded-xl py-1 px-4 min-w-[80px] hover:backdrop-brightness-200"
        :style="{color: props.category.color, borderColor: props.category.color}">
        {{ props.category.title }}
      </button>
      <p class="text-sm text-textLight dark:text-textDark">{{ formattedDate }}</p>
    </div>

    <div class="mx-4">
      <h2 class="font-bold"> {{ userName }} </h2>
      <p class="text-textLight dark:text-textDark"> {{ props.text }} </p>
    </div>
  </div>
</template>