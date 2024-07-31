import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import dayjs from 'dayjs';
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import 'element-plus/theme-chalk/display.css'

const app = createApp(App)
function formatDate(dateString,formatString) {
    const date = dayjs(dateString);
    // Then specify how you want your dates to be formatted
    return date.format(formatString);
}

app.config.globalProperties.$formatDate = formatDate;
app.use(router)
app.use(ElementPlus)
app.mount('#app')

