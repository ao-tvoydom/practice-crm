import { createApp } from 'vue'
import App from './App.vue'
import './assets/tailwind.css'
import router from './router'
import './assets/datepicker.scss'

let app = createApp(App)
app.use(router)
app.mount('#app')



