import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faHouse, faBars, faCirclePlus, faUser } from '@fortawesome/free-solid-svg-icons'

library.add(faHouse, faBars, faCirclePlus, faUser);


const app = createApp(App)

app.use(router)
app.component('font-awesome-icon', FontAwesomeIcon);
app.mount('#app')
