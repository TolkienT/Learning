<template>
    <header>
        <title>登录</title>
    </header>

    <div class="login">
        <Particles id="tsparticles" :particlesInit="particlesInit" class="login__particles" :options="options" />
        <div class="loginPart">
            <h2>用户登录</h2>
            <el-form ref="ruleFormRef" status-icon :rules="rules" :model="user" label-width="100px"
                style="transform:translate(-30px);">
                <!-- el-from-item 的 prop 属性必须与 el-input 中需要校验的表单属性一致 -->
                <el-form-item prop="userName">
                    <!-- 如果要用 rules 进行表单校验，那么 el-input 绑定的元素必须是 el-form 的 model 的直接属性，否则会导致校验失败 -->
                    <el-input class="input" v-model="user.userName" placeholder="请输入账号" maxlength="20" clearable />
                </el-form-item>
                <el-form-item prop="password">
                    <el-input class="input" type="password" v-model="user.password" placeholder="请输入密码" maxlength="20"
                        show-password clearable />
                </el-form-item>
                <!-- <el-form-item prop="verifyCode">
                    <el-input class="input" placeholder="请输入验证码" v-model="user.verifyCode" maxlength="4" clearable />
                    <img class="verifyCodeImg">
                </el-form-item> -->
                <el-button class="btn" type="primary" @click="onSubmit(ruleFormRef)">登录</el-button>
                <!-- <el-button class="btn" type="primary" @click="onShow">登录</el-button> -->
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
import type { FormInstance } from 'element-plus'
import { ElMessage } from "element-plus";

const particlesInit = async (engine: Engine) => {
    await loadFull(engine)
}

onMounted(() => {

})
//from表单校验
const ruleFormRef = ref<FormInstance>()
// 这里存放数据
const user = reactive({
    userName: '',
    password: '',
    verifyCode: ''
})

//校验
const validatePassword = (rule: any, value: any, callback: any) => {
    if (value === '' || value === null) {
        callback(new Error('请输入密码'))
    } else {
        callback()
    }
}
const validateAccount = (rule: any, value: any, callback: any) => {
    if (value === '' || value === null) {
        callback(new Error('请输入账号'))
    } else {
        callback()
    }
}
// const validateVerification = (rule: any, value: any, callback: any) => {
//     if (value === '' || value === null) {
//         callback(new Error('请输入验证码'))
//     } else {
//         callback()
//     }
// }
//校验
const rules = reactive({
    password: [{ validator: validatePassword, trigger: 'blur' }],
    userName: [{ validator: validateAccount, trigger: 'blur' }],
    // verifyCode: [{ validator: validateVerification, trigger: 'blur' }],
})
const changeRegist = () => {
    //replace直接替换，无法返回上一个页面
    // router.replace('/regist')
    
    router.push('/regist')
}

const onSubmit = (formEl: FormInstance | undefined) => {
    var _this: any = this;
    if (!formEl) return
    formEl.validate((valid: boolean) => {
        if (valid) {
            login(user).then((res: any) => {
                if (res.status == 200) {
                    window.localStorage.token = res.data.token
                    window.localStorage.expires = res.data.expiresTime
                    ElMessage({
                        message: '登录成功',
                        type: 'success'
                    })
                    router.push('/dashboard')
                } else {
                    ElMessage.error('账号或密码错误')
                }
            }).catch(error => {
                console.log(error)
                ElMessage.error(error.message)
            })
        }


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

const isShow = ref(false);

const onShow = () => {
    isShow.value = true;
};

const onClose = () => {
    isShow.value = false;
};

const onSuccess = () => {
    onSubmit(ruleFormRef.value);

    onClose(); // 验证成功，手动关闭模态框
};

</script>

<style scoped>
@import "../assets/styles/login.scss";
</style>
