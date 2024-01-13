<script setup lang="ts">
import axios from '../Helpers/AxiosInstance'
import { useRoute, useRouter } from 'vue-router'
import { store } from '@/Helpers/Authenticated'
import PageTitle from '@/components/PageTitle.vue'
import { useToast } from 'vue-toastification'

const route = useRoute();
const router = useRouter();
const toast = useToast();

const handleIconClick = (node: any) => {
  node.props.suffixIcon = node.props.suffixIcon === 'eye' ? 'eyeClosed' : 'eye'
  node.props.type = node.props.type === 'password' ? 'text' : 'password'
}

const loginHandler = async (credentials: any) => {
  try {
    let response = await axios.post('User/login', credentials)
    axios.patch(`User/device-token/${localStorage.getItem('device_token')}`);
    store.isAuthenticated = true;
    store.userId = response.data.id;

    const redirectPath = route.query.redirect || '/home'

    router.push({ path: redirectPath});
  } catch (data) {
    toast.error(data?.response.data.message);
  }
}
</script>

<template>
  <PageTitle title="Login" />
  <FormKit type="form" @submit="loginHandler" submit-label="Login">
    <FormKit
      type="email"
      name="email"
      label="Email"
      placeholder="client@gmail.com"
      validation="email|required"
      validation-visibility="live"
    />

    <FormKit
      type="password"
      name="password"
      label="Password"
      placeholder="password"
      validation="required|length:8"
      prefix-icon="password"
      suffix-icon="eyeClosed"
      @suffix-icon-click="handleIconClick"
      validation-visibility="live"
    />
    <p class="text-textLight dark:text-textDark mb-4 text-xs">
      Don't have an account?
      <RouterLink to="/signup" class="underline text-purple-800 dark:text-purple-400"
        >Sign up</RouterLink
      >
    </p>
  </FormKit>
</template>