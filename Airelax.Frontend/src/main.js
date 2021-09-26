import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import VCalendar from 'v-calendar';
import Carousel from "v3-carousel";
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

const options = {
    confirmButtonColor: '#ff385c',
    cancelButtonColor: '#ff385c',
};

createApp(App).use(store).use(router).use(Carousel).use(VCalendar, {}).use(VueSweetalert2,options).mount('#app')
