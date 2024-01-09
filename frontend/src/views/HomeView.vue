<script setup lang="ts">
import { Category, type ICategory } from '@/models/Category'
import { ref } from 'vue'
import CategoryDisplay from '@/components/CategoryDisplay.vue'

const categories = ref<ICategory[]>([])
const areCategoriesLoaded = ref(false);

const categoryWorker = new Category()
const fetchCategories = async () => {
  categories.value = await categoryWorker.all()
  areCategoriesLoaded.value = true;
}

fetchCategories()
</script>

<template>
  <div>
    <h1 class="text-2xl text-textLight dark:text-textDark mb-8">Home</h1>
  </div>

  <div v-if="areCategoriesLoaded" class="
    flex overflow-x-auto m-4 whitespace-nowrap pb-4
">
    <CategoryDisplay v-for="item in categories" :title="item.title" :color="item.color" />
  </div>
</template>