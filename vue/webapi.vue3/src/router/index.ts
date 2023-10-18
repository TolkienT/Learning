import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Layout from "../views/Layout.vue"
import About from "../views/AboutView.vue"
import SysParam from "../views/Settings/SysParam.vue"
// import TestEdit from "../views/Test/TestEdit.vue"
// import TestSignalR from "../views/Test/TestSignalR.vue"
import TestTs from '../views/Test/TestTs.vue'

// export const Layout = () => import("@/layout/index.vue");

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
    path: '/page',
    component: Layout,
    meta: {
      showNavBar: true
    },
    children: [
      {
        path: '/page/about',
        name: 'about',
        component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue'),
        meta: {
          keepAlive: true
        }
      }, {
        path: '/page/sysParam',
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
  history: createWebHistory(process.env.BASE_URL),
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
