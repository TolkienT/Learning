import { createRouter, createWebHistory,createWebHashHistory, RouteRecordRaw } from 'vue-router'
export const Layout = () => import("@/layout/index.vue");

// 静态路由
// export const constantRoutes: RouteRecordRaw[] = [
//   {
//     path: "/login",
//     component: () => import('../views/Login.vue'),
//     meta: { hidden: true },
//   },

//   {
//     path: "/",
//     name: "/",
//     component: Layout,
//     redirect: "/dashboard",
//     children: [
//       {
//         path: "dashboard",
//         component: () => import("../views/dashboard/index.vue"),
//         name: "Dashboard", // 用于 keep-alive, 必须与SFC自动推导或者显示声明的组件name一致
//         // https://cn.vuejs.org/guide/built-ins/keep-alive.html#include-exclude
//         meta: {
//           title: "dashboard",
//           icon: "homepage",
//           affix: true,
//           keepAlive: true,
//         },
//       },
//       // {
//       //   path: "401",
//       //   component: () => import("@/views/error-page/401.vue"),
//       //   meta: { hidden: true },
//       // },
//       // {
//       //   path: "404",
//       //   component: () => import("@/views/error-page/404.vue"),
//       //   meta: { hidden: true },
//       // },
//     ],
//   }

//   // 外部链接
//   // {
//   //   path: "/external-link",
//   //   component: Layout,
//   //   children: [ {
//   //       component: () => import("@/views/external-link/index.vue"),
//   //       path: "https://www.cnblogs.com/haoxianrui/",
//   //       meta: { title: "外部链接", icon: "link" },
//   //     },
//   //   ],
//   // },
//   // 多级嵌套路由
//   /* {
//          path: '/nested',
//          component: Layout,
//          redirect: '/nested/level1/level2',
//          name: 'Nested',
//          meta: {title: '多级菜单', icon: 'nested'},
//          children: [
//              {
//                  path: 'level1',
//                  component: () => import('@/views/nested/level1/index.vue'),
//                  name: 'Level1',
//                  meta: {title: '菜单一级'},
//                  redirect: '/nested/level1/level2',
//                  children: [
//                      {
//                          path: 'level2',
//                          component: () => import('@/views/nested/level1/level2/index.vue'),
//                          name: 'Level2',
//                          meta: {title: '菜单二级'},
//                          redirect: '/nested/level1/level2/level3',
//                          children: [
//                              {
//                                  path: 'level3-1',
//                                  component: () => import('@/views/nested/level1/level2/level3/index1.vue'),
//                                  name: 'Level3-1',
//                                  meta: {title: '菜单三级-1'}
//                              },
//                              {
//                                  path: 'level3-2',
//                                  component: () => import('@/views/nested/level1/level2/level3/index2.vue'),
//                                  name: 'Level3-2',
//                                  meta: {title: '菜单三级-2'}
//                              }
//                          ]
//                      }
//                  ]
//              },
//          ]
//      }*/
// ];

// /**
//  * 创建路由
//  */
// const router = createRouter({
//   history: createWebHashHistory(),
//   routes: constantRoutes as RouteRecordRaw[],
//   // 刷新时，滚动条位置还原
//   scrollBehavior: () => ({ left: 0, top: 0 }),
// });







import HomeView from '../views/HomeView.vue'
import About from "../views/AboutView.vue"
import SysParam from "../views/Settings/SysParam.vue"
// import TestEdit from "../views/Test/TestEdit.vue"
// import TestSignalR from "../views/Test/TestSignalR.vue"
import TestTs from '../views/Test/TestTs.vue'
const routes: Array<RouteRecordRaw> = [
    {
        path: '/home',
        name: 'home',
        component: HomeView,
        meta: {
            showNavBar: true
        }
    },
    {
        path: '/',
        name: 'login',
        meta: {
            title: '登录',
            showNavBar: false
        },
        component: () => import('../views/Login.vue')
    },
    {
        path: '/dashboard',
        component: Layout,
        redirect: "/dashboard/home",
        meta: {
            showNavBar: true
        },
        children: [
            {
                path: '/dashboard/home',
                name: 'Home',
                component: () => import("../views/dashboard/index.vue"),
                meta: {
                    title: "dashboard",
                    icon: "homepage",
                    affix: true,
                    keepAlive: true,
                },
            }, {
                path: '/dashboard/sysParam',
                component: SysParam
            },
            // {
            //   path: '/signalr',
            //   component: TestSignalR
            // }
            // {
            //   path: '/edit',
            //   component: TestEdit
            // },

        ]

    },
    {
        path: '/page/testTs',
        component: TestTs
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, from, next) => {
    var title: string = 'XXXX';
    /* 路由发生变化修改页面title */
    if (typeof (to.meta?.title) === 'string') {
        title = to.meta.title;
    }
    document.title = title
    next()
})

export default router
