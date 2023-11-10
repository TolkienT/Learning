<script setup lang="ts">
import { ref } from "vue";
import { ElMessage } from "element-plus";
</script>
<template>
    <section>
        <!--工具条-->
        <el-col>
            <el-button :type="primary">按键</el-button>
        </el-col>

        <el-table style="width: 100%">
            <el-table-column type="index" label="序号" width="80"> </el-table-column>
            <el-table-column prop="param_code" label="参数编码" width=""> </el-table-column>
            <el-table-column prop="param_name" label="参数名称" width=""> </el-table-column>
        </el-table>

        <el-col :span="24">
            <el-pagination layout="prev,pager,next" :page-size="50"></el-pagination>
        </el-col>
    </section>
</template>

<style>
#app .header {
    height: 60px;
    line-height: 60px;
    background: #2f3e52;
    color: #fff;
}
</style>