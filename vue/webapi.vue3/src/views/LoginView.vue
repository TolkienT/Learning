<template>
    <div class="login">
        <Particles id="tsparticles" :particlesInit="particlesInit" class="login__particles" :options="options" />
        <div class="loginPart">
            <h2>用户登录</h2>
            <el-form ref="ruleFormRef" status-icon :rules="rules" label-width="100px" class="demo-ruleForm"
                style="transform:translate(-30px);">
                <el-form-item prop="account">
                    <el-input class="input" placeholder="请输入账号" maxlength="20" clearable />
                </el-form-item>
                <el-form-item prop="password">
                    <el-input type="password" placeholder="请输入密码" maxlength="20" show-password clearable />
                </el-form-item>
                <el-form-item prop="verifyCode">
                    <el-input placeholder="请输入验证码" maxlength="4" clearable />
                    <img class="verifyCodeImg">
                </el-form-item>
                <el-button class="btn" type="primary" @click="onSubmit(ruleFormRef)">登录</el-button>
                <div style="text-align: right;transform:translate(0,30px);">
                    <el-link class="link" type="warning" @click="changeRegist">没有账号？去注册</el-link>
                </div>
            </el-form>
        </div>
    </div>
</template>

<script setup lang="ts">
import { reactive, ref, onMounted } from 'vue'
import router from '@/router/index'
import { loadFull } from "tsparticles"
import type { Engine } from 'tsparticles-engine'
import { login } from '@/api/security/user';
// import { tokenStore, accountStore } from '@/store/modules/user'
// import { loginReq } from '@/api/types/loginReq'
import type { FormInstance } from 'element-plus'
// import { encode, decode } from 'js-base64';

const particlesInit = async (engine: Engine) => {
    await loadFull(engine)
}


onMounted(() => {

})
//from表单校验
const ruleFormRef = ref<FormInstance>()
// 这里存放数据
// const user = reactive<loginReq>({
//     account: '',
//     password: '',
//     verifyCode: ''
// })
// const users = reactive<loginReq>({
//     account: '',
//     password: '',
//     verifyCode: ''
// })
//校验
const validatePassword = (rule: any, value: any, callback: any) => {
    if (value === '') {
        callback(new Error('请输入密码'))
    } else {
        callback()
    }
}
const validateAccount = (rule: any, value: any, callback: any) => {
    if (value === '') {
        callback(new Error('请输入账号'))
    } else {
        callback()
    }
}
const validateVerification = (rule: any, value: any, callback: any) => {
    if (value === '') {
        callback(new Error('请输入验证码'))
    } else {
        callback()
    }
}
//校验
const rules = reactive({
    password: [{ validator: validatePassword, trigger: 'blur' }],
    account: [{ validator: validateAccount, trigger: 'blur' }],
    verifyCode: [{ validator: validateVerification, trigger: 'blur' }],
})
const changeRegist = () => {
    router.replace('/regist')
}
// let imgUrl = ref("http://localhost:8080/api/login/verifyCode?time=" + new Date());
// const resetImg = () => {
//     imgUrl.value = "http://localhost:8080/api/login/verifyCode?time=" + new Date();
// }

const onSubmit = (formEl: FormInstance | undefined) => {
    var model={
            UserName:'tang.zx',
            Password:'qwe123'
        }
        login(model).then((res)=>{
            debugger
            console.log(res)
        })
    if (!formEl) return
    formEl.validate((valid) => {
        var model={
            UserName:'tang.zx',
            Password:'qwe123'
        }
        login(model).then((res)=>{
            debugger
            console.log(res)
        })
        // if (valid) {
        //     Object.keys(user).forEach((key) => {
        //         if (key == 'account' || key == 'password') {
        //             users[key] = encode(user[key])
        //         } else {
        //             users[key] = user[key]
        //         }
        //     })
        //     login(users).then((res) => {
        //         if (res.data.code == 90000) {
        //             ElMessage({
        //                 message: '登录成功',
        //                 type: 'success'
        //             })
        //             // 把信息存储到全局变量中
        //             tokenStore().setToken(res.data.data.token)
        //             accountStore().setAccount(res.data.data.account)
        //             // 2. 跳转到  elem 后台！！！
        //             router.push('/homePage')
        //             // window.location.href="../../../public/backgroudhtml/backgroud.html"
        //         } else {
        //             ElMessage.error("账号或验证码错误！")
        //         }
        //     }).catch(error => {
        //         ElMessage.error("账号或验证码错误！")
        //     })
        // } else {
        //     ElMessage.error("错误的提交！")
        //     return false
        // }
    })
}
const options = {
    fpsLimit: 60,
    interactivity: {
        detectsOn: 'canvas',
        events: {
            onClick: { // 开启鼠标点击的效果
                enable: true,
                mode: 'push'
            },
            onHover: { // 开启鼠标悬浮的效果(线条跟着鼠标移动)
                enable: true,
                mode: 'grab'
            },
            resize: true
        },
        modes: { // 配置动画效果
            bubble: {
                distance: 400,
                duration: 2,
                opacity: 0.8,
                size: 40
            },
            push: {
                quantity: 4
            },
            grab: {
                distance: 200,
                duration: 0.4
            },
            attract: { // 鼠标悬浮时，集中于一点，鼠标移开时释放产生涟漪效果
                distance: 200,
                duration: 0.4,
                factor: 5
            }
        }
    },
    particles: {
        color: {
            value: '#BA55D3' // 粒子点的颜色
        },
        links: {
            color: '#FFBBFF', // 线条颜色
            distance: 150,//线条距离
            enable: true,
            opacity: 0.4, // 不透明度
            width: 1.2 // 线条宽度
        },
        collisions: {
            enable: true
        },
        move: {
            attract: { enable: false, rotateX: 600, rotateY: 1200 },
            bounce: false,
            direction: 'none',
            enable: true,
            out_mode: 'out',
            random: false,
            speed: 0.5, // 移动速度
            straight: false
        },
        number: {
            density: {
                enable: true,
                value_area: 800
            },
            value: 80//粒子数
        },
        opacity: {//粒子透明度
            value: 0.7
        },
        shape: {//粒子样式
            type: 'star'
        },
        size: {//粒子大小
            random: true,
            value: 3
        }
    },
    detectRetina: true
}
</script>

<style scoped>
@import "../assets/styles/login.scss";
</style>
