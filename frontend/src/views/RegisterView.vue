<script setup lang="ts">
import PageTitle from '@/components/PageTitle.vue'

const handleIconClick = (node:any) => {
  node.props.suffixIcon = node.props.suffixIcon === 'eye' ? 'eyeClosed' : 'eye'
  node.props.type = node.props.type === 'password' ? 'text' : 'password'
}

const registerHandler = (credentials:any) => {
  let payload = {
    username: credentials.username,
    email: credentials.email,
    password: credentials.password
  }
  console.log('Register: ', payload);
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