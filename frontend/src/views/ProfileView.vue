<script setup lang="ts">
import axios from '../Helpers/AxiosInstance'
import { store } from '@/Helpers/Authenticated'
import router from '@/router'
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
  <h1 class="text-textLight
                dark:text-textDark
                font-bold text-2xl mb-4
    ">Profile</h1>
  <button @click="logoutHandler" class="
    bg-purple-500 dark:bg-purple-500 hover:bg-purple-400 hover:dark:bg-purple-400
    p-2 rounded-md
  ">Log out</button>
</template>