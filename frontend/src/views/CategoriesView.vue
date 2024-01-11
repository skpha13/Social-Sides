<script setup lang="ts">
import PageTitle from '@/components/PageTitle.vue'
import { Category, type ICategory } from '@/models/Category'
import { ref } from 'vue'
import CategorySection from '@/components/CategorySection.vue'
import { JoinCategory } from '@/models/JoinCategory'

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

const joinCategory = async (id: string) => {
  let payload = {
    id: id
  }

  const joinWorker = new JoinCategory();
  let response = await joinWorker.join(payload);
  // TODO: notification/message here
  console.log(response);
  areCategoriesLoaded.value = false;
  categories.value = await categoryWorker.all();
  areCategoriesLoaded.value = true;
}

</script>

<template>
  <PageTitle title="Categories" />

  <div v-if="areCategoriesLoaded"
       class="m-4">
    <CategorySection v-for="item in categories"
                     @join-category="id => joinCategory(id)"
                     :key="item.id"
                     :id="item.id"
                     :title="item.title"
                     :color="item.color" />
  </div>
</template>