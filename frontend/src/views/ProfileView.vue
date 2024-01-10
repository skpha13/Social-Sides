<script setup lang="ts">
import axios from '../Helpers/AxiosInstance'
import { store } from '@/Helpers/Authenticated'
import router from '@/router'
import PageTitle from '@/components/PageTitle.vue'
const logoutHandler = async () => {
  try {
    axios.post('User/logout');
    store.isAuthenticated = false;
    router.push({ name: 'login' });
  } catch (data) {
    console.log(data);
  }
}
</script>

<template>
  <PageTitle title="Profile" />
  <button @click="logoutHandler" class="
    bg-purple-500 dark:bg-purple-500 hover:bg-purple-400 hover:dark:bg-purple-400
    p-2 rounded-md
  ">Log out</button>
</template>