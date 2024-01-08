<script setup lang="ts">
const handleIconClick = (node, e) => {
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
  <h1 class="text-textLight
                dark:text-textDark
                font-bold text-2xl mb-4
    ">Sign Up</h1>
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