<script setup lang="ts">
import type { ICategory } from '@/models/Category'
import type { IUser } from '@/models/User'
import { getTimeElapsed } from '@/utils/DateUtils'

const props = defineProps<{
  text: string
  user: IUser
  category: ICategory
  date: string
}>();

const formattedDate: string = getTimeElapsed(props.date);
</script>

<template>
  <div class="w-96 sm:w-[512px] sm:mx-8 py-2 px-4 border rounded-lg border-borderLight-default dark:border-borderDark-default">
    <div class="flex flex-row justify-between mb-2">
      <button
        class="text-sm border rounded-xl py-1 px-4 min-w-[80px]"
        :style="{color: props.category.color, borderColor: props.category.color}">
        {{ props.category.title }}
      </button>
      <p class="text-sm text-textLight dark:text-textDark">{{ formattedDate }}</p>
    </div>

    <div class="mx-4">
      <h2 class="font-bold"> {{ props.user.userName }} </h2>
      <p class="text-textLight dark:text-textDark"> {{ props.text }} </p>
    </div>
  </div>
</template>