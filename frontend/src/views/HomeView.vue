<script setup lang="ts">
import { Category, type ICategory } from '@/models/Category'
import { Post, type IPost } from '@/models/Post'
import { ref } from 'vue'
import CategoryDisplay from '@/components/CategoryDisplay.vue'
import PostCard from '@/components/PostCard.vue'
import PageTitle from '@/components/PageTitle.vue'
import { Like } from '@/models/Like'
import { useToast } from 'vue-toastification'
import type { IComment } from '@/models/Comment'
import CommentsPopUp from '@/components/CommentsPopUp.vue'

const toast = useToast();

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

const postWorker = new Post()

const fetchPosts = async () => {
  posts.value = await postWorker.all('?include=category,user,comments');
  arePostsLoaded.value = true;
}

fetchPosts();
// ===============================

// ======== LIKE ACTION ========
const likeWorker = new Like();
const handleLike = async (payload: any, index: number) => {
  try {
    if (payload.option) {
      posts.value[index].totalLikes += 1;
      let response = await likeWorker.like(payload.postId);
      fetchPosts();
    } else {
      posts.value[index].totalLikes -= 1;
      let response = await likeWorker.unlike(payload.postId);
      fetchPosts();
    }
  } catch (error: any) {
    toast.error(error);
  }
}
// =============================

// ======== COMMENTS ACTION ========
const commentWorker = new Comment();
const postId = ref<string>("");
const commentsPopup = ref<IComment[]>([]);
const showPopup = ref<boolean>(false);

const handleCommentsPopup = (payload: any) => {
  commentsPopup.value = payload.comments;
  postId.value = payload.postId;
  showPopup.value = true;
}

const closePopup = () => {
  showPopup.value = false;
}
// =================================
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
    <PostCard v-for="(item, index) in posts" :key="item.id"
              :id="item.id"
              :text="item.text"
              :total-likes="item.totalLikes"
              :is-liked="item.isLikedByUser"
              :category="item.relations.category"
              :user="item.relations.user"
              :comments="item.relations.comments"
              :date="item.dateCreated"
              @like-action="handleLike($event,index)"
              @comment-popup="handleCommentsPopup"
    />
  </div>

  <CommentsPopUp v-if="showPopup"
                 @close-popup="closePopup"
                 :comments="commentsPopup"
                 :postId="postId"
  />
</template>