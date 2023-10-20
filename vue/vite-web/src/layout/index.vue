<script setup lang="ts">

import Sidebar from "./components/Sidebar/index.vue";


</script>

<template>
    <div>
        <Sidebar class="sidebar-container" />
    </div>

</template>

<style lang="scss" scoped>

.sidebar-container {
    z-index: 800;
    display: flex;
    width: 100% !important;
    height: 50px;

    :deep(.el-scrollbar) {
      flex: 1;
      min-width: 0;
      height: 50px;
    }
  }


</style>