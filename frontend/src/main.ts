import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import { defaultConfig, plugin } from '@formkit/vue'
import config from '../formkit.config'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faBars, faCirclePlus, faHouse, faPlus, faUser, faHeart } from '@fortawesome/free-solid-svg-icons'
import { faHeart as faHeartRegular, faMessage } from '@fortawesome/free-regular-svg-icons'

import Toast, { type PluginOptions, POSITION } from 'vue-toastification'
import 'vue-toastification/dist/index.css'

library.add(faHouse, faBars, faCirclePlus, faUser, faPlus ,faHeart, faHeartRegular, faMessage);

const app = createApp(App)

const options: PluginOptions = {
  position: POSITION.BOTTOM_RIGHT
};

app.use(router)
app.use(plugin, defaultConfig(config));
app.use(Toast, options);
app.component('font-awesome-icon', FontAwesomeIcon);
app.mount('#app')