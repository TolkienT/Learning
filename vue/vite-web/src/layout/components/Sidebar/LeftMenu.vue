<script setup lang="ts">
import { useRoute } from "vue-router";
import SidebarItem from "./SidebarItem.vue";
import { useAppStore } from "@/store/modules/app";
import path from "path-browserify";
import { isExternal } from "@/utils/index";

const appStore = useAppStore();

const props = defineProps({
  menuList: {
    required: true,
    default: () => {
      return [];
    },
    type:Array<any>
  },
  basePath: {
    type: String,
    required: true,
  }
});

/**
 * 解析路径
 *
 * @param routePath 路由路径
 */
function resolvePath(routePath: string) {
  if (isExternal(routePath)) {
    return routePath;
  }
  if (isExternal(props.basePath)) {
    return props.basePath;
  }

  // 完整路径 = 父级路径(/level/level_3) + 路由路径
  const fullPath = path.resolve(props.basePath, routePath); // 相对路径 → 绝对路径
  return fullPath;
}

</script>

<template>
  <!-- <el-menu
    :default-active="layout === 'top' ? '-' : currRoute.path"
    :collapse="!appStore.sidebar.opened"
    :background-color="variables.menuBg"
    :text-color="variables.menuText"
    :active-text-color="variables.menuActiveText"
    :unique-opened="false"
    :collapse-transition="false"
    :mode="layout === 'top' ? 'horizontal' : 'vertical'"
  >
    <sidebar-item
      v-for="route in menuList"
      :key="route.path"
      :item="route"
      :base-path="resolvePath(route.path)"
      :is-collapse="!appStore.sidebar.opened"
    />
  </el-menu> -->

  <el-menu :unique-opened="false" :collapse-transition="false" :mode="'horizontal'">
    <sidebar-item v-for="route in menuList" :key="route.path" :item="route" :base-path="resolvePath(route.path)"
      :is-collapse="!appStore.sidebar.opened" />
  </el-menu>
</template>