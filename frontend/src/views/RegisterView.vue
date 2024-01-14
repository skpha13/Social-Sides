<script setup lang="ts">
import PageTitle from '@/components/PageTitle.vue'
import axios from '../Helpers/AxiosInstance'
import { store } from '@/Helpers/Authenticated'
import { useRoute, useRouter } from 'vue-router'
import { useToast } from 'vue-toastification'

const route = useRoute();
const router = useRouter();
const toast = useToast();


const handleIconClick = (node:any) => {
  node.props.suffixIcon = node.props.suffixIcon === 'eye' ? 'eyeClosed' : 'eye'
  node.props.type = node.props.type === 'password' ? 'text' : 'password'
}

const registerHandler = async (credentials:any) => {
  let payload = {
    username: credentials.username,
    email: credentials.email,
    password: credentials.password
  }

  try {
    let response = await axios.post('User/register', payload);
    toast.success(response.data.message);
    router.push({ name: 'home' });
  } catch (error) {
    toast.error(error?.response.data.message);
  }
}

</script>

<template>
  <PageTitle title="Sign Up" />
  <FormKit type="form" @submit="registerHandler" submit-label="Sign Up">
    <FormKit type="text"
             name="username"
             label="Username"
             placeholder="client"
             validation="required"
             validation-visibility="live" />

    <FormKit type="email"
             name="email"
             label="Email"
             placeholder="client@gmail.com"
             validation="email|required"
             validation-visibility="live" />

      <FormKit type="password"
               name="password"
               label="Password"
               placeholder="password"
               prefix-icon="password"
               suffix-icon="eyeClosed"
               @suffix-icon-click="handleIconClick"
               validation="required|length:8"
               validation-visibility="live" />

      <FormKit type="password"
               name="password_confirm"
               label="Confirm password"
               validation="required|confirm"
               validation-visibility="live"
               validation-label="Confirmation" />
    </FormKit>
</template>