<script setup lang="ts">
const handleIconClick = (node, e) => {
  node.props.suffixIcon = node.props.suffixIcon === 'eye' ? 'eyeClosed' : 'eye'
  node.props.type = node.props.type === 'password' ? 'text' : 'password'
}

const loginHandler = (credentials:any) => {
  console.log('Login: ', credentials);
}

</script>

<template>
    <h1 class="text-textLight
                dark:text-textDark
                font-bold text-2xl mb-4
    ">Login</h1>
    <FormKit type="form" @submit="loginHandler" submit-label="Login">
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
               validation="required|length:8"
               prefix-icon="password"
               suffix-icon="eyeClosed"
               @suffix-icon-click="handleIconClick"
               validation-visibility="live" />
    </FormKit>
</template>