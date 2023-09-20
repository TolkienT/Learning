import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Layout from "../views/Layout.vue"
import About from "../views/AboutView.vue"
import SysParam from "../views/Settings/SysParam.vue"

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
    path: '/login',
    name: 'login',
    meta: {
      title: '登录',
      showNavBar: false
    },
    component: () => import('../views/Login.vue')
  },
  {
    path: '/',
    component: Layout,
    meta: {
      showNavBar: true
    },
    children: [
      {
        path: '/about',
        name: 'about',
        component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue'),
        meta: {
          keepAlive: true
        }
      }, {
        path: '/sysParam',
        component: SysParam
      }
    ]

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
