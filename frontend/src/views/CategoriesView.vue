<script setup lang="ts">
import PageTitle from '@/components/PageTitle.vue'
import { Category, type ICategory } from '@/models/Category'
import { ref } from 'vue'
import CategorySection from '@/components/CategorySection.vue'

// ======== CATEGORY FETCHING ========
const categories = ref<ICategory[]>([])
const areCategoriesLoaded = ref(false);

const categoryWorker = new Category();
const fetchCategories = async () => {
  categories.value = await categoryWorker.all();
  areCategoriesLoaded.value = true;
}

fetchCategories();
// ====================================

</script>

<template>
  <PageTitle title="Categories" />

  <div v-if="areCategoriesLoaded" class="m-4">
    <CategorySection v-for="item in categories"
                     :key="item.id"
                     :id="item.id"
                     :title="item.title"
                     :color="item.color" />
  </div>
</template>