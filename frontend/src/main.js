import 'bootstrap/dist/css/bootstrap.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import dayjs from 'dayjs';

const app = createApp(App)
function formatDate(dateString,formatString) {
    const date = dayjs(dateString);
    // Then specify how you want your dates to be formatted
    return date.format(formatString);
}
app.config.globalProperties.$formatDate = formatDate;
app.use(router)

app.mount('#app')
import 'bootstrap/dist/js/bootstrap.js'

