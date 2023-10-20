import { RouteRecordRaw } from "vue-router";
import { defineStore } from "pinia";
import { constantRoutes } from "@/router";
import { store } from "@/store";

const modules = import.meta.glob("../../views/**/**.vue");
const Layout = () => import("@/layout/index.vue");

/**
 * 递归过滤有权限的异步(动态)路由
 *
 * @param routes 接口返回的异步(动态)路由
 * @param roles 用户角色集合
 * @returns 返回用户有权限的异步(动态)路由
 */
const filterAsyncRoutes = (routes: RouteRecordRaw[], roles: string[]) => {
    const asyncRoutes: RouteRecordRaw[] = [];

    routes.forEach((route) => {
        const tmpRoute = { ...route }; // ES6扩展运算符复制新对象
        if (!route.name) {
            tmpRoute.name = route.path;
        }
        // 判断用户(角色)是否有该路由的访问权限
        if (true) {
            if (tmpRoute.component?.toString() == "Layout") {
                tmpRoute.component = Layout;
            } else {
                const component = modules[`../../views/${tmpRoute.component}.vue`];
                if (component) {
                    tmpRoute.component = component;
                } else {
                    tmpRoute.component = modules[`../../views/error-page/404.vue`];
                }
            }

            if (tmpRoute.children) {
                tmpRoute.children = filterAsyncRoutes(tmpRoute.children, roles);
            }

            asyncRoutes.push(tmpRoute);
        }
    });

    return asyncRoutes;
};

// setup
export const usePermissionStore = defineStore("permission", () => {
    // state
    const routes = ref<RouteRecordRaw[]>([]);
    
    // actions
    function setRoutes(newRoutes: RouteRecordRaw[]) {
        routes.value = constantRoutes.concat(newRoutes);
    }
    /**
     * 生成动态路由
     *
     * @param roles 用户角色集合
     * @returns
     */
    // function generateRoutes(roles: string[]) {
    //     return new Promise<RouteRecordRaw[]>((resolve, reject) => {
    //         // 根据角色获取有访问权限的路由
    //         const accessedRoutes = filterAsyncRoutes(datas, roles);
    //         setRoutes(accessedRoutes);
    //         resolve(accessedRoutes);
    //     });
    // }

    /**
     * 混合模式左侧菜单
     */
    const mixLeftMenu = ref<RouteRecordRaw[]>([]);
    function getMixLeftMenu(activeTop: string) {
        routes.value.forEach((item) => {
            if (item.path === activeTop) {
                mixLeftMenu.value = item.children || [];
            }
        });
    }
    return { routes, setRoutes, getMixLeftMenu, mixLeftMenu };
});