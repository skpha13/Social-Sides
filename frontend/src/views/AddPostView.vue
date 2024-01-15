<script setup lang="ts">
import PageTitle from '@/components/PageTitle.vue'
import { useToast } from 'vue-toastification'
import { ref } from 'vue'
import { Category, type ICategory } from '@/models/Category'

const toast = useToast();

interface IOptions {
  label: string,
  value: string
}

// ======== CATEGORY FETCHING ========
const categories = ref<ICategory[]>([]);
const options = ref<IOptions[]>([]);
const areCategoriesLoaded = ref(false);

const categoryWorker = new Category();
const fetchCategories = async () => {
  categories.value = await categoryWorker.all();
  options.value = categories.value.map((iterator) => {
    return {
      label: iterator.title,
      value: iterator.id
    }
  });
  areCategoriesLoaded.value = true;
}

fetchCategories();
// ====================================

const addingPostHandler = async () => {

}

</script>

<template>
  <PageTitle title="Add Post" />
  <FormKit v-if="areCategoriesLoaded" type="form" @submit="addingPostHandler" submit-label="Add Post">
    <FormKit
      type="textarea"
      label="Text"
      placeholder="Say something"
      name="text"
      validation="required"
      validation-visibility="live"
    />

    <FormKit
      type="select"
      label="Category"
      placeholder="Select a category"
      name="categoryId"
      :options="options"
      validation="required"
      validation-visibilty="live"
    />
  </FormKit>
</template>