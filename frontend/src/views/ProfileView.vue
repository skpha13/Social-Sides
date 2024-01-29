<script setup lang="ts">
import axios from '../Helpers/AxiosInstance'
import { store } from '@/Helpers/Authenticated'
import router from '@/router'
import PageTitle from '@/components/PageTitle.vue'
import { useToast } from 'vue-toastification'

const toast = useToast();
const logoutHandler = async () => {
  try {
    axios.post('User/logout');
    store.isAuthenticated = false;
    router.push({ name: 'login' });
  } catch (data) {
    console.log(data);
  }
}

const updateProfileHandler = async (payload: any) => {
  try {
    let response = await axios.patch('User/update', payload);
    toast.success(response.data.message);
  } catch (data) {
    console.log(data);
    toast.error("Failed to update profile");
  }
}
</script>

<template>
  <PageTitle title="Profile" />

  <FormKit type="form" @submit="updateProfileHandler" submit-label="Update">
    <FormKit
      type="text"
      name="userName"
      label="Username"
      placeholder="user"
    />

    <FormKit
      type="email"
      name="email"
      label="Email"
      placeholder="client@gmail.com"
      validation="email"
      validation-visibility="live"
    />
  </FormKit>

  <button @click="logoutHandler"
    class="inline-flex w-80 justify-center gap-x-1.5 rounded-md
          bg-backgroundLight-mute px-3 py-2 text-sm font-semibold
          text-textLight hover:bg-backgroundLight-soft
          dark:bg-backgroundDark-mute dark:text-textDark hover:dark:bg-backgroundDark-soft"
    >Log out</button>
</template>