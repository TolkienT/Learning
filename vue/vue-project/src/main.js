import { createApp } from 'vue'


import './assets/main.css'
const app=createApp({
    data(){
        return{
            count:0
        }
    }
});
app.mount('#app');
