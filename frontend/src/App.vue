<script lang="ts" setup>
import { RouterLink, RouterView } from 'vue-router'
import { Menu, MenuButton, MenuItem, MenuItems } from '@headlessui/vue'
import axios from 'axios'
import { getMessaging, getToken, onMessage } from 'firebase/messaging'
import { initializeApp } from 'firebase/app'

const firebaseConfig = {
  apiKey: 'AIzaSyAltoopxGHEOdVn6SF_XclpA12fuW62z6s',
  authDomain: 'social-sides.firebaseapp.com',
  projectId: 'social-sides',
  storageBucket: 'social-sides.appspot.com',
  messagingSenderId: '1097571377356',
  appId: '1:1097571377356:web:20bd0458b8531926d9e269',
  measurementId: 'G-6WVLHMM4PQ'
}
// Initialize Firebase
const app = initializeApp(firebaseConfig)
const messaging = getMessaging()

onMessage(messaging, (payload) => {
  // TODO: display this message on top of window
  console.log('Message received. ', payload.notification)
})

getToken(messaging, {
  vapidKey:
    'BD5l-2RLtmqmRE8jyYypgZHPl1LlfxFhPzaQWL5GadRaY80y_lkcKTRP9XhN8rrpEJZpLHl5exZm5A23qF2zrgs'
})
  .then((currentToken) => {
    if (currentToken) {
      // TODO: send it to backend
      console.log(currentToken)
    } else {
      console.log('No registration token available. Request permission to generate one.')
    }
  })
  .catch((err) => {
    console.log('An error occurred while retrieving token. ', err)
  })

const toggleTheme = () => {
  if (localStorage.getItem('theme')) {
    if (localStorage.getItem('theme') === 'light') {
      document.documentElement.classList.remove('dark')
    } else {
      document.documentElement.classList.add('dark')
    }
  } else {
    document.documentElement.classList.remove('dark')
    if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
      document.documentElement.classList.add('dark')
    } else {
      document.documentElement.classList.remove('dark')
    }
  }
}

const changeThemeLight = () => {
  localStorage.theme = 'light'
  toggleTheme()
}

const changeThemeDark = () => {
  localStorage.theme = 'dark'
  toggleTheme()
}

const changeThemeOS = () => {
  localStorage.removeItem('theme')
  toggleTheme()
}

// TODO: create axios instance class to remove {withCredentials: true}
const login = async () => {
  try {
    let payload = {
      email: 'mal13adi03@gmail.com',
      password: 'parolaskpha'
    }
    const response = await axios.post('https://localhost:7116/api/User/login', payload, {
      withCredentials: true
    })
    console.log(response.data)

     let payload2 =
         {
           "id": "439c82bf-f8cd-4300-a467-03a1f85a6d63",
           "userName": "skpha3",
           "email": "test@gmail.com",
           "password": "test123test"
         }
     const response2 = await axios.patch("https://localhost:7116/api/User/update",payload2, {withCredentials: true});
     console.log(response2);
  } catch (error) {
    console.log(error)
  }
}

// login();
</script>

<template>
  <header>
    <nav class="mb-10">
      <div class="flex justify-between">
        <h1 class="font-bold text-3xl">Social-Sides</h1>
        <!-- DROPDOWN BUTTON FOR COLOR SCHEME -->
        <Menu as="div" class="relative inline-block text-left">
          <div>
            <MenuButton
              class="inline-flex w-full justify-center gap-x-1.5 rounded-md
              bg-backgroundLight-mute px-3 py-2 text-sm font-semibold
              text-textLight hover:bg-backgroundLight-soft
              dark:bg-backgroundDark-mute dark:text-textDark hover:dark:bg-backgroundDark-soft"
            >
              Theme
            </MenuButton>
          </div>

          <transition
            enter-active-class="transition ease-out duration-100"
            enter-from-class="transform opacity-0 scale-95"
            enter-to-class="transform opacity-100 scale-100"
            leave-active-class="transition ease-in duration-75"
            leave-from-class="transform opacity-100 scale-100"
            leave-to-class="transform opacity-0 scale-95"
          >
            <MenuItems
              class="absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md
                              bg-backgroundLight-mute shadow-lg ring-1 ring-backgroundLight-mute ring-opacity-5 focus:outline-none
                              dark:bg-backgroundDark-mute dark:ring-backgroundDark-mute"
            >
              <div class="py-1">
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a
                    :class="[
                      active ? 'bg-backgroundLight-soft text-textLight dark:bg-backgroundDark-soft dark:text-textDark' : 'text-textLight dark:text-textDark',
                      'block px-4 py-2 text-sm'
                    ]"
                    @click="changeThemeOS"
                    >System Default</a
                  >
                </MenuItem>
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a
                    :class="[
                      active ? 'bg-backgroundLight-soft text-textLight dark:bg-backgroundDark-soft dark:text-textDark' : 'text-textLight dark:text-textDark',
                      'block px-4 py-2 text-sm'
                    ]"
                    @click="changeThemeLight"
                    >Light</a
                  >
                </MenuItem>
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a
                    :class="[
                       active ? 'bg-backgroundLight-soft text-textLight dark:bg-backgroundDark-soft dark:text-textDark' : 'text-textLight dark:text-textDark',
                      'block px-4 py-2 text-sm'
                    ]"
                    @click="changeThemeDark"
                    >Dark</a
                  >
                </MenuItem>
              </div>
            </MenuItems>
          </transition>
        </Menu>
        <!-- DROPDOWN BUTTON FOR COLOR SCHEME -->
      </div>
    </nav>
  </header>

  <RouterView />

  <div
    class="fixed bottom-0 left-0 w-full z-50 border-t border-borderLight-default dark:border-borderDark-default"
  >
    <div class="flex flex-row items-center justify-between p-2 px-10">
<!--      TODO: replace paths of RouterLinks-->
      <RouterLink to="/feed">
        <font-awesome-icon icon="fa-solid fa-house"
                           class="text-textHeading dark:text-textHeading"
                           size="xl"
        />
      </RouterLink>
      <RouterLink to="/feed">
        <font-awesome-icon icon="fa-solid fa-bars"
                           class="text-textHeading dark:text-textHeading"
                           size="xl"
        />
      </RouterLink>
      <RouterLink to="/feed">
        <font-awesome-icon icon="fa-solid fa-circle-plus"
                           class="text-textHeading dark:text-textHeading"
                           size="xl"
        />
      </RouterLink>
      <RouterLink to="/feed">
        <font-awesome-icon icon="fa-solid fa-user"
                           class="text-textHeading dark:text-textHeading"
                           size="xl"
        />
      </RouterLink>
    </div>
  </div>
</template>
