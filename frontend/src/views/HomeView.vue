<script setup lang="ts">
import { Category, type ICategory } from '@/models/Category'
import { Post, type IPost } from '@/models/Post'
import { ref } from 'vue'
import CategoryDisplay from '@/components/CategoryDisplay.vue'
import PostCard from '@/components/PostCard.vue'
import PageTitle from '@/components/PageTitle.vue'

// ======== CATEGORY FETCHING ========
const categories = ref<ICategory[]>([])
const areCategoriesLoaded = ref(false);

const categoryWorker = new Category();
const fetchCategories = async () => {
  categories.value = await categoryWorker.all('?include=user');
  areCategoriesLoaded.value = true;
}

fetchCategories();
// ====================================

// ======== POST FETCHING ========
const posts = ref<IPost[]>([]);
const arePostsLoaded = ref(false);

const postWoker = new Post()

const fetchPosts = async () => {
  posts.value = await postWoker.all('?include=category,user,comments');
  arePostsLoaded.value = true;
}

fetchPosts();
// ===============================
</script>

<template>
  <PageTitle title="Home" />

<!-- TODO: clicking on a category loads posts only from it -->
  <div v-if="areCategoriesLoaded" class="flex overflow-x-auto m-4 whitespace-nowrap pb-4">
    <CategoryDisplay
      v-for="item in categories"
      :key="item.id"
      :id="item.id"
      :title="item.title"
      :color="item.color"
    />
  </div>

  <div v-if="arePostsLoaded" class="flex flex-col items-center sm:items-start">
    <PostCard v-for="item in posts" :key="item.id"
              :text="item.text"
              :category="item.relations.category"
              :user="item.relations.user"
              :date="item.dateCreated" />
  </div>
</template>