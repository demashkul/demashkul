import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import './assets/main.css'
import PrimeVue from 'primevue/config';

import InputText from 'primevue/inputtext';
import Button from "primevue/button";
import Dropdown from "primevue/dropdown";

import 'primevue/resources/themes/saga-blue/theme.css'       //theme
import 'primevue/resources/primevue.min.css'                 //core css
import 'primeicons/primeicons.css' 

const app = createApp(App)

app.use(router)
app.use(PrimeVue);
app.component('Button', Button);
app.component('InputText', InputText);
app.component('Dropdown', Dropdown);

app.mount('#app')
