import { createApp } from 'vue'
import './style.css'
import Antd from 'ant-design-vue'
import App from './App.vue'
import router from './router'
import { setupStore } from "@/store";
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import * as ElementPlusIconsVue from '@element-plus/icons-vue'
import zhCn from "element-plus/es/locale/lang/zh-cn";//国际化
import { createPinia } from 'pinia'
import Particles from 'particles.vue3'

const app = createApp(App);

setupStore(app);

// 实例化 Pinia
const pinia = createPinia()

app.use(ElementPlus, { locale: zhCn })
app.use(Particles)
app.use(router)
app.use(pinia)
app.use(Antd)
app.mount('#app')

//全局注册图标组件
for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
    app.component(key, component)
}