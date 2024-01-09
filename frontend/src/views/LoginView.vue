<script setup lang="ts">
import axios from '../Helpers/AxiosInstance'
import { type RouteLocationRaw, useRoute, useRouter } from 'vue-router'
import { store } from '../Helpers/Authenticated'

const route = useRoute();
const router = useRouter();

const handleIconClick = (node: any) => {
  node.props.suffixIcon = node.props.suffixIcon === 'eye' ? 'eyeClosed' : 'eye'
  node.props.type = node.props.type === 'password' ? 'text' : 'password'
}

const loginHandler = async (credentials: any) => {
  try {
    let response = await axios.post('User/login', credentials)
    store.isAuthenticated = true

    // TODO: notification here
    console.log(response.data.message)
    const redirectPath = route.query.redirect || '/home'

    router.push({ path: redirectPath});
  } catch (data) {
    console.log(data.data)
  }
}
</script>

<template>
  <h1 class="text-textLight dark:text-textDark font-bold text-2xl mb-4">Login</h1>
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