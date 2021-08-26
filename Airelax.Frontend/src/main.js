import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import VCalendar from 'v-calendar';
import Carousel from "v3-carousel";

createApp(App).use(store).use(router).use(Carousel).use(VCalendar, {}).mount('#app')
