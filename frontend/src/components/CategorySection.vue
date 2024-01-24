<script setup lang="ts">
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { Category } from '@/models/Category'
import { ref } from 'vue'

const props = defineProps<{
  id: string
  title: string
  color: string
}>();

const emit = defineEmits<{
  (e: 'join-category', id: string): void,
  (e: 'unjoin-category', id:string): void
}>();
interface ICategoryId {
  id: string
}

// ======== CATEGORY FETCHING ========
const categories = ref<ICategoryId[]>([])
const map = ref<Map<string,boolean>>(new Map<string,boolean>());
const areCategoriesLoaded = ref(false);

const categoryWorker = new Category();
const fetchCategories = async () => {
  categories.value = await categoryWorker.all('/with?user=true');
  areCategoriesLoaded.value = true;

  categories.value.map((category) => {
    map.value.set(category.id, true);
  });
}

fetchCategories();
// ====================================

const checkCategoryMembership = () => {
  return !map.value.get(props.id);
}

</script>

<template>
  <div class="flex flex-row justify-between hover:cursor-pointer
              text-xl mb-6 border-b">
    <h1>{{ props.title }}</h1>
    <div v-if="checkCategoryMembership()" @click="emit('join-category',props.id)"
          class="flex items-center w-24 justify-between border rounded-lg px-4 mb-2 hover:backdrop-brightness-200"
          :style="{color: props.color, borderColor: props.color}">
      <p class="text-base font-semibold">Join</p>
      <FontAwesomeIcon icon="fa-solid fa-plus" size="sm" class="relative top-[0.04rem]"/>
    </div>
    <div v-else
         @click="emit('unjoin-category', props.id)"
         class="flex items-center w-24 justify-center border rounded-lg px-4 mb-2 hover:cursor-pointer"
         :style="{borderColor: props.color, background: props.color}">
      <p class="text-base font-semibold text-backgroundLight-default dark:text-backgroundDark-default">Unfollow</p>
    </div>
  </div>
</template>