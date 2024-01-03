<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import { Menu, MenuButton, MenuItem, MenuItems } from '@headlessui/vue'
import axios from "axios"
import { getMessaging, getToken, onMessage } from "firebase/messaging";
import { initializeApp } from "firebase/app";

const firebaseConfig = {
  apiKey: "AIzaSyAltoopxGHEOdVn6SF_XclpA12fuW62z6s",
  authDomain: "social-sides.firebaseapp.com",
  projectId: "social-sides",
  storageBucket: "social-sides.appspot.com",
  messagingSenderId: "1097571377356",
  appId: "1:1097571377356:web:20bd0458b8531926d9e269",
  measurementId: "G-6WVLHMM4PQ"
};
// Initialize Firebase
const app = initializeApp(firebaseConfig);
const messaging = getMessaging();

onMessage(messaging, (payload) => {
  // TODO: display this message on top of window
  console.log('Message received. ', payload.notification);
});


getToken(messaging, { vapidKey: 'BD5l-2RLtmqmRE8jyYypgZHPl1LlfxFhPzaQWL5GadRaY80y_lkcKTRP9XhN8rrpEJZpLHl5exZm5A23qF2zrgs' }).then((currentToken) => {
  if (currentToken) {
    // TODO: send it to backend
    console.log(currentToken);
  } else {
    console.log('No registration token available. Request permission to generate one.');
  }
}).catch((err) => {
  console.log('An error occurred while retrieving token. ', err);
});

const toggleTheme = () => {
  if (localStorage.getItem('theme')) {
    if (localStorage.getItem('theme') === 'light') {
      document.documentElement.classList.remove('dark');
    } else {
      document.documentElement.classList.add('dark');
    }
  } else {
    document.documentElement.classList.remove('dark');
    if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
      document.documentElement.classList.add('dark');
    } else {
      document.documentElement.classList.remove('dark');
    }
  }
}

const changeThemeLight = () => {
  localStorage.theme = 'light';
  toggleTheme();
}

const changeThemeDark = () => {
  localStorage.theme = 'dark';
  toggleTheme();
}

const changeThemeOS = () => {
  localStorage.removeItem('theme');
  toggleTheme();
}

// TODO: create axios instance class to remove {withCredentials: true}
const login = async () => {
  try {
    let payload = {
      "email": "mal13adi03@gmail.com",
      "password": "parolaskpha"
    }
    const response = await axios.post("https://localhost:7116/api/User/login", payload, {withCredentials: true});
    console.log(response.data);


   /* let payload2 =
        {
          "id": "439c82bf-f8cd-4300-a467-03a1f85a6d63",
          "userName": "skpha3",
          "email": "test@gmail.com",
          "password": "test123test"
        }
    const response2 = await axios.patch("https://localhost:7116/api/User/update",payload2, {withCredentials: true});
    console.log(response2);*/

  } catch (error) {
    console.log(error);
  }
}

// login();

</script>

<template>
  <header>
    <div class="wrapper">
      <nav class="flex justify-between">
        <RouterLink to="/feed">Feed</RouterLink>

        <div class="block m-2 p-2">
          <h1 class="text-3xl">TEST</h1>
        </div>
        <!-- DROPDOWN BUTTON FOR COLOR SCHEME -->
        <Menu as="div" class="relative inline-block text-left">
          <div>
            <MenuButton class="inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 hover:bg-gray-50">
              Theme
            </MenuButton>
          </div>

          <transition enter-active-class="transition ease-out duration-100" enter-from-class="transform opacity-0 scale-95" enter-to-class="transform opacity-100 scale-100" leave-active-class="transition ease-in duration-75" leave-from-class="transform opacity-100 scale-100" leave-to-class="transform opacity-0 scale-95">
            <MenuItems class="absolute right-0 z-10 mt-2 w-32 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
              <div class="py-1">
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a @click="changeThemeOS" :class="[active ? 'bg-gray-100 text-gray-900' : 'text-gray-700', 'block px-4 py-2 text-sm']">System Default</a>
                </MenuItem>
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a @click="changeThemeLight" :class="[active ? 'bg-gray-100 text-gray-900' : 'text-gray-700', 'block px-4 py-2 text-sm']">Light</a>
                </MenuItem>
                <MenuItem v-slot="{ active }" class="cursor-pointer">
                  <a @click="changeThemeDark" :class="[active ? 'bg-gray-100 text-gray-900' : 'text-gray-700', 'block px-4 py-2 text-sm']">Dark</a>
                </MenuItem>
              </div>
            </MenuItems>
          </transition>

        </Menu>

      </nav>
    </div>
  </header>

  <RouterView />
</template>