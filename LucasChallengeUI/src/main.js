import "bootstrap/dist/css/bootstrap.css";
import {createApp} from "vue";
import App from "./App.vue";
import router from "./router";
import VueTheMask from 'vue-the-mask'; 
import Vue3Toastify from 'vue3-toastify';

const app = createApp(App);

app.use(VueTheMask);

app.use(router);

app.mount("#app");
