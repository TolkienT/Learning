<script setup lang="ts">
import { useTransition, TransitionPresets } from "@vueuse/core";
import { computed } from 'vue'

console.log('dashboard')

defineOptions({
    // eslint-disable-next-line
    name: "Dashboard",
    inheritAttrs: false,
});

const date: Date = new Date();

const greetings = computed(() => {
    const hours = date.getHours();
    if (hours >= 6 && hours < 8) {
        return "晨起披衣出草堂，轩窗已自喜微凉🌅！";
    } else if (hours >= 8 && hours < 12) {
        return "上午好🌞！";
    } else if (hours >= 12 && hours < 18) {
        return "下午好☕！";
    } else if (hours >= 18 && hours < 24) {
        return "晚上好🌃！";
    } else if (hours >= 0 && hours < 6) {
        return "偷偷向银河要了一把碎星，只等你闭上眼睛撒入你的梦中，晚安🌛！";
    }
});


</script>
<template>
    <div class="dashboard-container">
        <!-- 用户信息 -->
        <el-row class="mb-8">
            <el-card class="w-full">
                <div class="flex justify-between flex-wrap">
                    <div class="flex items-center">

                        <span class="ml-[10px] text-[16px]">
                            昵称
                        </span>
                    </div>

                    <div class="leading-[40px]">
                        {{ greetings }}
                    </div>

                    <div class="space-x-2 flex items-center justify-end">
                        <el-link target="_blank" type="danger"
                            href="https://blog.csdn.net/u013737132/article/details/130191394">💥官方从零到一文档</el-link>
                        <el-divider direction="vertical" />
                        <el-link target="_blank" type="success" href="https://gitee.com/youlaiorg">Gitee</el-link>
                        <el-divider direction="vertical" />
                        <el-link target="_blank" type="primary" href="https://github.com/youlaitech">GitHub
                        </el-link>
                    </div>
                </div>
            </el-card>
        </el-row>
    </div>
</template>

<style lang="scss" scoped>
.dashboard-container {
    position: relative;
    padding: 24px;

    .user-avatar {
        width: 40px;
        height: 40px;
        border-radius: 50%;
    }
}
</style>